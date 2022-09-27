using System;

namespace CommunicationServicesWithInterfaces
{
    interface ICommunicationService
    {
        void SendCommunication(MessageModel messagelModel);
    }

    class MessageModel // gave it a different name - more general
    {
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public bool IsApproved { get; set; }
        public string Comment { get; set; }
        public string PhoneNumber { get; set; }
    }


    class EmailService : ICommunicationService
    {
        public void SendCommunication(MessageModel messagelModel) // taking object instead of separate arguments, also changed name
        {
            string message;

            if (messagelModel.IsApproved == true)
            {
                message = "Your request was approved. Thank you for your contribution!";
            }
            else
            {
                message = "Your request was denied. " + "Reason: " + messagelModel.Comment;
            }

            Console.WriteLine("Email was sent!");
            Console.WriteLine($"Dear {messagelModel.FirstName},{Environment.NewLine}{message}.{Environment.NewLine}Email sent to {messagelModel.EmailAddress}"); // {Environment.NewLine}Approved by {emailModel.ApprovedBy}
        }
    }

    class TextMessageService : ICommunicationService
    {
        public void SendCommunication(MessageModel messagelModel)
        {

            string message;

            if (messagelModel.IsApproved == true)
            {
                message = "Your request was approved. Thank you for your contribution!";
            }
            else
            {
                message = "Your request was denied. " + "Reason: " + messagelModel.Comment;
            }

            Console.WriteLine("Text was sent!");
            Console.WriteLine($"Dear {messagelModel.FirstName},{Environment.NewLine}{message}{Environment.NewLine}Text sent to {messagelModel.PhoneNumber}"); // {Environment.NewLine}Approved by {emailModel.ApprovedBy}
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            // Post Controller
            MessageModel email = new MessageModel();
            email.EmailAddress = "dmitry@hennepin.us";
            email.PhoneNumber = "555-555-5555";
            email.FirstName = "Dmitry";
            email.IsApproved = false;
            email.Comment = "Similar abbreviation exists";
            DataPostService(email, new EmailService());

            Console.WriteLine("------------------------------------");

            // Put Controller
            MessageModel text = new MessageModel();
            text.EmailAddress = "chad@hennepin.us";
            text.PhoneNumber = "444-444-4444";
            text.FirstName = "Chad";
            text.IsApproved = true;
            DataPutService(text, new TextMessageService());
        }

        static void DataPostService(MessageModel messageModel, ICommunicationService communication) // same parameters
        {
            // Database work
            Console.WriteLine("New abbreviation was created");

            // communication was sent via email
            communication.SendCommunication(messageModel);
        }

        static void DataPutService(MessageModel messageModel, ICommunicationService communication) // same parameters
        {
            // Database work
            Console.WriteLine("Abbreviation was updated");

            // communication was sent via text
            communication.SendCommunication(messageModel);
        }
    }
}

