using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pverify;

namespace pVerify_Demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Pverify.Apis.ElgSummary.Verify
            var apiId = "xxx";
            var clientSecret = "xxx";
            Pverify.Apis.PverifyClient.Init(apiId, clientSecret);

            var request = new Pverify.Apis.EligibilitySummaryRequest();
            request.Subscriber = new Pverify.Apis.Subscriber
            {
                MemberId = "xxx"
                ,
                FirstName = "Robert"
                ,
                LastName = "xxx"
                ,
                DOB = "01/01/2000"
            };
            request.IsSubscriberPatient = true;
            request.Provider = new Pverify.Apis.Provider
            {
                NPI = "xxx"
                ,
                LastName = "Bressler"
            };
            request.DoS_StartDate = DateTime.Now.ToShortDateString();
            request.DoS_EndDate = request.DoS_StartDate;

            request.PayerCode = "00001";
            //"Insufficient information to generate patient search.\r\nAllowed Search Criteria(s) for the Payer are 
            //: \r\n1.Dep DOB,Member ID\r\n.2.Sub First Name,Sub Last Name,Dep First Name,Dep Last Name,Dep DOB\r\n"
            var output = Pverify.Apis.ElgSummary.Verify(request);


        }

        private void button2_Click(object sender, EventArgs e)
        {
            var apiId = "xxx";
            var clientSecret = "xxx";
            Pverify.Apis.PverifyClient.Init(apiId, clientSecret);
            var request = new Pverify.Apis.SOSRequest();
            request.PatientFirstName = "xxx";
            request.PatientLastName = "xxx";
            request.PatientDOB = "xxx";
            request.MemberId = "xxx";
            request.PatientStateCode = "CA";
            request.HCPCSCodes = "E1430";
            request.DOSStart = "05/14/2020";
            request.DOSEnd = request.DOSStart;
            var output = Pverify.Apis.SameOrSimilar.Verify(request);

            System.Threading.Thread.Sleep(1000 * 60*1); // 1 min delay
            var newoutput = Pverify.Apis.SameOrSimilar.GetSameOrSimilarResponse((int)output.RequestId); // long vs int

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var apiId = "xxx";
            var clientSecret = "xxx";
            Pverify.Apis.PverifyClient.Init(apiId, clientSecret);
            var request = new Pverify.Apis.SNFRequest();
            request.PayerCode = "00007";
            request.MemberId = "xxx";
            request.PatientFirstName = "xx";
            request.PatientLastName = "xx";
            request.PatientDOB = "08/02/1952";
            request.PatientStateCode = "SC";
            request.DOS = "11/13/2019";

            var output = Pverify.Apis.SNF.Verify(request);

            System.Threading.Thread.Sleep(1000 * 60 * 1); // 1 min delay
            var newoutput = Pverify.Apis.SNF.GetSNFResponse((int)output.RequestId);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            var apiId = "xxx";
            var clientSecret = "xxx";
            Pverify.Apis.PverifyClient.Init(apiId, clientSecret);
            var request = new Pverify.Apis.MBIRequest();
            request.PatientSSN = "xxx";
            request.PatientFirstName = "xxx";
            request.PatientLastName = "xxx";
            request.PatientDOB = "10/01/1947";
            var output = Pverify.Apis.MBI.Verify(request);

            System.Threading.Thread.Sleep(1000 * 60 * 1); // 1 min delay
            var newoutput = Pverify.Apis.MBI.GetMBIResponse((int)output.RequestId);
            // this works

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Pverify.Apis.ElgSummary.Verify
            var apiId = "xxx";
            var clientSecret = "xxx";
            Pverify.Apis.PverifyClient.Init(apiId, clientSecret);

            var request = new Pverify.Apis.EligibilitySummaryRequest();
            request.Subscriber = new Pverify.Apis.Subscriber
            {
                MemberId = "xxx"
                ,
                FirstName = "xxx"
                ,
                LastName = "xx"
                ,
                DOB = "04/05/1955"
            };
            request.IsSubscriberPatient = true;
            request.Provider = new Pverify.Apis.Provider
            {
                NPI = "xxx"
                ,
                LastName = "Bressler"
            };
            request.DoS_StartDate = DateTime.Now.ToShortDateString();
            request.DoS_EndDate = request.DoS_StartDate;

            request.PayerCode = "00007";
            //request.PracticeTypeCode = "12";
            //"Insufficient information to generate patient search.\r\nAllowed Search Criteria(s) for the Payer are 
            //: \r\n1.Dep DOB,Member ID\r\n.2.Sub First Name,Sub Last Name,Dep First Name,Dep Last Name,Dep DOB\r\n"
            var output = Pverify.Apis.ElgSummary.Verify(request);
        }
    }
}
