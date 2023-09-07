namespace Raspored.Models
{
    public class ShiftChangeRequest
    {
        public int Id { get; set; }
        public int FirstShiftId { get; set; }
        public Shift FirstShift { get; set; }
        public int SecondShiftId { get; set; }
        public Shift SecondShift { get; set; }
        public int FirstTeamMemberId { get; set; }
        public TeamMember FirstTeamMember { get; set; }
        public int SecondTeamMemberId { get; set; }
        public TeamMember SecondTeamMember { get; set; }
        public string RequestStatus { get; set; }
        public string RequestMessage { get; set; }
    }
}
