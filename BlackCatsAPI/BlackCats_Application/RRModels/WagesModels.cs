namespace BlackCats_Application.RRModels
{
    public class WagesResponse
    {
        public int DailyWages { get; set; }

        public int NoOfWorkingDays { get; set; }

        public DateOnly WageMonth { get; set; }

        public int PFDeduction { get; set; }

        public int ESICDeduction { get; set; }

        public Guid EmployeeId { get; set; }
    }

    public class WagesRequest : WagesResponse
    {

    }

    public class WagesUpdateRequest : WagesRequest
    {
        public Guid Id { get; set; }
    }

    public class WagesUpdateResponse : WagesResponse
    {

    }
}
