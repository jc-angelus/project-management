namespace ProjectManagementUI.Models
{

    /// <summary>
    /// Developer: Johans Cuellar
    /// Created: 09/02/2023
    /// Class: ErrorViewModel
    /// </summary>
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}