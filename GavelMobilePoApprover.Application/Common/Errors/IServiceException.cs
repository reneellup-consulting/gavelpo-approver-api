using System.Net;

namespace GavelMobilePoApprover.Application.Common.Errors;
public interface IServiceException {
    public HttpStatusCode StatusCode { get; }
    public string ErrorMessage { get; }
}
