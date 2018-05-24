namespace Terminal_Sessions_Logger
{
    internal class SessionModel
    {   
        public string Server { get; set; }
        public string UserID { get; set; }
        public int SessionID { get; set; }
        public string ClientName { get; set; }   
        public int CurrentHour { get; set; }
    }
}
