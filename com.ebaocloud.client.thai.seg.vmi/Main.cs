﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyHttp.Http;
using Newtonsoft.Json.Linq;
using System.Dynamic;

using com.ebaocloud.client.thai.seg.vmi.api;
using com.ebaocloud.client.thai.seg.vmi.parameters;
using com.ebaocloud.client.thai.seg.vmi.response;
using com.ebaocloud.client.thai.seg.vmi.pub;

namespace com.ebaocloud.client.thai.seg.vmi
{
    public class TestNetwork
    {

        public void testCalc() {
            PolicyService service = new PolicyServiceImpl();
            // Login request
            // You should record the TOKEN after login in order to call the other APIs.
            LoginResp resp = service.Login("TIB_01", "Seg@1234");

            // Prepare request parameters.
            var calculationParams = new CalculationParams();

            // Required properties
            calculationParams.effectiveDate = DateTime.Now.ToLocalTime();
            calculationParams.expireDate = DateTime.Now.AddYears(1).ToLocalTime();
            calculationParams.proposalDate = DateTime.Now.ToLocalTime();
            calculationParams.planCode = "SCDG";
            calculationParams.productCode = "VMI";
            calculationParams.vehicleGarageType = VehicleGarageType.DEALER;
            calculationParams.vehicleMakeName = "TOYOTA";
            calculationParams.vehicleModelName = "COROLLA";
            calculationParams.vehicleModelDescription = "TOYO20160104";
            calculationParams.vehicleModelYear = 2016;
            calculationParams.vehicleRegistrationYear = 2016;
            calculationParams.vehicleUsage = VehicleUsage.PRIVATE;
            // Optional properties
            calculationParams.vehicleAccessaryValue = 1000;

            // Invoke service method to get result.
            CalculationResp calcResp = service.Calculate(resp.token, calculationParams);

            if (calcResp.success)
            {
                Console.WriteLine(calcResp);
            }
            else
            {
                Console.WriteLine("Calculate succcess: false" + "\nMessage:" + calcResp.errorMessage);
            }
        }

        public void testIssue() {

            PolicyService service = new PolicyServiceImpl();
            LoginResp resp = service.Login("TIB_01", "Seg@1234");
            Console.WriteLine(resp);

            var calculationParams = new CalculationParams();
            calculationParams.effectiveDate = DateTime.Now.ToLocalTime();
            calculationParams.expireDate = DateTime.Now.AddYears(1).ToLocalTime();
            calculationParams.proposalDate = DateTime.Now.ToLocalTime();

            calculationParams.planCode = "SCDG";
            calculationParams.productCode = "VMI";
            calculationParams.vehicleAccessaryValue = 1000;
            calculationParams.vehicleGarageType = VehicleGarageType.DEALER;
            calculationParams.vehicleMakeName = "TOYOTA";
            calculationParams.vehicleModelName = "COROLLA";
            calculationParams.vehicleModelDescription = "TOYO20160104";
            calculationParams.vehicleModelYear = 2016;
            calculationParams.vehicleRegistrationYear = 2016;
            calculationParams.vehicleUsage = VehicleUsage.PRIVATE;
            //Console.WriteLine(calculationParams);
            //CalculationResp calcResp = service.Calculate(resp.token, calculationParams);
            //Console.WriteLine(calcResp);

            Policy policyParam = new Policy();
            List<Document> documents = new List<Document>();
            Document doc = new Document();
            doc.category = DocumentCategory.DRIVING_LICENSE;
            doc.name = "test";
            doc.file = new System.IO.FileInfo("D:/eBaoCloud-SEA/designtime/tenant_logo/SEG_TH/SEG_TH_md.png");
            documents.Add(doc);
            policyParam.documents = documents;

            policyParam.effectiveDate = DateTime.Now.ToLocalTime();
            policyParam.expireDate = DateTime.Now.AddYears(1).ToLocalTime();
            policyParam.proposalDate = DateTime.Now.ToLocalTime();
            policyParam.productCode = "VMI";
            policyParam.planCode = "SCDG";
            //policyParam.productVersion = "v1";
            policyParam.isPayerSameAsPolicyholder = false;

            String randomStr = new Random(DateTime.Now.Millisecond).Next().ToString();
            policyParam.insured = new Insured();
            policyParam.insured.vehicleChassisNo = "CNNN" + randomStr;
            // policyParam.insured.vehicleColor = "white";
            policyParam.insured.vehicleCountry = "THA";
            policyParam.insured.vehicleModelDescription = "TOYO20160104";
            policyParam.insured.vehicleGarageType = VehicleGarageType.DEALER;
            policyParam.insured.vehicleMakeName = "TOYOTA";
            policyParam.insured.vehicleModelName = "COROLLA";
            policyParam.insured.vehicleProvince = "THA";
            policyParam.insured.vehicleRegistrationNo = "RNNNM" + randomStr;
            policyParam.insured.vehicleRegistrationYear = 2016;
            policyParam.insured.vehicleUsage = VehicleUsage.PRIVATE;
            policyParam.insured.vehicleModelYear = 2016;

            policyParam.payer = new Payer();
            policyParam.payer.inThaiAddress = new InThaiAddress();
            policyParam.payer.inThaiAddress.district = "1001";
            policyParam.payer.inThaiAddress.postalCode = "10200";
            policyParam.payer.inThaiAddress.province = "10";
            policyParam.payer.inThaiAddress.street = "songhu rd.";
            policyParam.payer.inThaiAddress.subDistrict = "100101";
            policyParam.payer.inThaiAddress.fullAddress = "24 (318 เดิม) ซ.อุดมสุข30 แยก2 ถ.อุดมสุข แขวงบางนา เขตบางนา กทม. 10260";
            policyParam.payer.name = "leon luo";


            policyParam.indiPolicyholder = new IndividualPolicyholder();
            policyParam.indiPolicyholder.idNo = "123456";
            policyParam.indiPolicyholder.idType = "1";
            policyParam.indiPolicyholder.inThaiAddress = new InThaiAddress();
            policyParam.indiPolicyholder.inThaiAddress.district = "1001";
            policyParam.indiPolicyholder.inThaiAddress.postalCode = "10200";
            policyParam.indiPolicyholder.inThaiAddress.province = "10";
            policyParam.indiPolicyholder.inThaiAddress.street = "songhu rd.";
            policyParam.indiPolicyholder.inThaiAddress.subDistrict = "100101";
            policyParam.indiPolicyholder.inThaiAddress.fullAddress = "24 (318 เดิม) ซ.อุดมสุข30 แยก2 ถ.อุดมสุข แขวงบางนา เขตบางนา กทม. 10260";
            policyParam.indiPolicyholder.lastName = "luo";
            policyParam.indiPolicyholder.firstName = "leon";
            policyParam.indiPolicyholder.mobile = "1234999";
            policyParam.indiPolicyholder.taxNo = "10000";
            policyParam.indiPolicyholder.title = IndividualPrefix.Khun;

            policyParam.drivers = new List<Driver>();
            Driver driver = new Driver();
            policyParam.drivers.Add(driver);
            driver.birthday = DateTime.Now;
            driver.firstName = "leon";
            driver.lastName = "luo";
            driver.occupation = "1233333";

            IssuedResp hi = service.Issue(resp.token, policyParam);
            Console.WriteLine(hi);
        }

        public static void Main(string[] args)
        {
           // new TestNetwork().testCalc();
            new TestNetwork().testIssue();
            Console.ReadKey();

        }

    }
}
