namespace Obilet.Core.Middlewares.Exceptions {
    public class JourjeyException : AppException {

        public string SessionId { get; set; }

        public string Error { get; set; }

        public Exception? Ex { get; set; }

        public JourjeyException(string sessionId, string error, Exception ex) {

            this.SessionId = sessionId;
            this.Error = error;
            this.Ex = ex;
        }

        public JourjeyException(string sessionId, string error) {

            this.SessionId = sessionId;
            this.Error = error;
        }
    }
}
