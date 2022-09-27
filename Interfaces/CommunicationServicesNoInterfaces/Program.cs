using System;

namespace CommunicationServicesNoInterfaces
{
    class EmailModel
    {
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public bool IsApproved { get; set; }
        public string Comment { get; set; }
        public string PhoneNumber { get; set; }
    }


    class EmailService
    {
        private readonly EmailModel emailModel;

        public EmailService(string emailAddress, string firstName, bool isApproved, string comment) // , string phoneNumber
        {
            emailModel = new EmailModel();

            emailModel.EmailAddress = emailAddress;
            emailModel.FirstName = firstName;
            emailModel.IsApproved = isApproved;
            emailModel.Comment = comment;
            //emailModel.PhoneNumber = phoneNumber;
        }

        public void SendEmail()
        {
            string message;

            if (emailModel.IsApproved == true)
            {
                message = "Your request was approved. Thank you for your contribution!";
            }
            else
            {
                message = "Your request was denied. " + "Reason: " + emailModel.Comment;
            }

            // email was sent
            Console.WriteLine($"Dear {emailModel.FirstName},{Environment.NewLine}{message}{Environment.NewLine}Email sent to {emailModel.EmailAddress}");
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            // Post Controller
            DataPostService();

            Console.WriteLine("-------------------------");

            // Put Controller
            DataPutService();
        }

        static void DataPostService()
        {
            string emailAddress = "dmitry@hennepin.us";
            string firstName = "Dmitry";
            bool isApproved = false; // was denied
            string comment = "Similar abbreviation exists";

            // Database work
            Console.WriteLine("New abbreviation was created");

            // communication was sent via email
            EmailService emailService = new EmailService(emailAddress, firstName, isApproved, comment);
            emailService.SendEmail();
        }

        static void DataPutService()
        {
            string emailAddress = "chad@hennepin.us";
            string firstName = "Chad";
            bool isApproved = true;
            string comment = "Similar abbreviation exists.";

            // Database work
            Console.WriteLine("Abbreviation was updated");

            // communication was sent via email
            EmailService emailService = new EmailService(emailAddress, firstName, isApproved, comment);
            emailService.SendEmail();
        }
    }
}