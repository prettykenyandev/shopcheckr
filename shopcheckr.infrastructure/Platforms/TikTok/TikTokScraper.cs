using Microsoft.Playwright;
using shopcheckr.domain.Entities;
using shopcheckr.domain.Enums;
using shopcheckr.domain.Interfaces;

namespace shopcheckr.infrastructure.Platforms.TikTok;

public class TikTokScraper : IShopScraper
{
    public async Task<List<ShopMention>> GetMentionsAsync(string shopHandle, PlatformType platformType)
    {
        var mentions = new List<ShopMention>();
        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(new() { Headless = true });
        var page = await browser.NewPageAsync();

        await page.GotoAsync($"https://www.tiktok.com/search?q={Uri.EscapeDataString(shopHandle)}");
        await page.WaitForTimeoutAsync(5000);

        var links = await page.QuerySelectorAllAsync("a[href*='/video/']");
        foreach (var link in links)
        {
            var href = await link.GetAttributeAsync("href");
            if (string.IsNullOrEmpty(href)) continue;

            await page.GotoAsync(href);
            await page.WaitForTimeoutAsync(5000);

            for (int i = 0; i < 5; i++)
            {
                await page.Mouse.WheelAsync(0, 1000);
                await page.WaitForTimeoutAsync(2000);
            }

            var commentElements = await page.QuerySelectorAllAsync("div[data-e2e='comment-item']");
            foreach (var el in commentElements)
            {
                var text = await el.InnerTextAsync();
                if (!string.IsNullOrEmpty(text) && text.Contains(shopHandle, StringComparison.OrdinalIgnoreCase))
                {
                    mentions.Add(new ShopMention(text, null, DateTime.UtcNow, href));
                }
            }
        }

        return mentions;
    }
}

