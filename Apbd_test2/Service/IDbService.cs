using Apbd_test2.Dto.Request;
using Apbd_test2.Dto.Response;

namespace Apbd_test2.Service;

public interface IDbService
{
    Task<RacerResponseDto> getRacerParticipation(int id);
    Task<String> addNewParticipation(RequestDto request);
}