using MediatR;
using shopcheckr.domain.Enums;

namespace shopcheckr.application.Queries.AnalyzeShopMentions;
public record AnalyzeShopMentionsQuery(string ShopHandle, PlatformType Platform) : IRequest<AnalyzeShopMentionsResult>;

