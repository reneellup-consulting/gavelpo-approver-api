using GavelMobilePoApprover.Application.Outstanding.Common;
using GavelMobilePoApprover.Application.Outstanding.Query.Count;
using GavelMobilePoApprover.Contracts.Order;
using Mapster;

namespace GavelMobilePoApprover.Api.Common.Mapping;
public class OrderMappingConfig : IRegister {
    public void Register(TypeAdapterConfig config) {

        config.NewConfig<OutstandingCountRequest, OutstandingCountQuery>();

        config.NewConfig<OutstandingCountResult, OutstandingCountResponse>();
    }
}
