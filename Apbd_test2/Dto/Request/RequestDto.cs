namespace Apbd_test2.Dto.Request;

public class RequestDto
{
    public string raceName { get; set; }
    public string trackName { get; set; }
    public List<ParticipanceDto> participations { get; set; }
}

public class ParticipanceDto
{
    public int racerId { get; set; }
    public int position { get; set; }
    public int finishTimeInSeconds { get; set; }
}