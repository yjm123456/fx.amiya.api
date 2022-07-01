using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class HouseDataPublishSaasCustomerSyncCustomerInfoRequest : JdRequestBase<HouseDataPublishSaasCustomerSyncCustomerInfoResponse>
    {
                                                                                                                                              public  	    Nullable<double>
              tradeAmt
 {get; set;}
                                                          
                                                          public  		string
              city
 {get; set;}
                                                          
                                                          public  	    Nullable<double>
              bookAmt
 {get; set;}
                                                          
                                                                                           public  		string
              project
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              tradeNums
 {get; set;}
                                                          
                                                          public  		string
              uuid
 {get; set;}
                                                          
                                                          public  		string
              customerName
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                           		public  		string
  attribute1 {get; set; }
                                                                                                                                                                                                public  		string
              venderName
 {get; set;}
                                                          
                                                          public  		string
              customerPhone
 {get; set;}
                                                          
                                                          public  		string
              recordTime
 {get; set;}
                                                          
                                                          public  		string
              brokerPhone
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                           		public  		string
  attribute2 {get; set; }
                                                                                                                                                                                                public  		string
              brokerName
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                           		public  		string
  attribute3 {get; set; }
                                                                                                                                                                                                public  	    Nullable<double>
              commisionAmt
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              status
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.house.data.publish.saas.customer.syncCustomerInfo";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("tradeAmt", this.            tradeAmt
);
                                                                                                        parameters.Add("city", this.            city
);
                                                                                                        parameters.Add("bookAmt", this.            bookAmt
);
                                                                                                                                                        parameters.Add("project", this.            project
);
                                                                                                        parameters.Add("tradeNums", this.            tradeNums
);
                                                                                                        parameters.Add("uuid", this.            uuid
);
                                                                                                        parameters.Add("customerName", this.            customerName
);
                                                                                                                                                parameters.Add("attribute1", this.            attribute1
);
                                                                                                                                parameters.Add("venderName", this.            venderName
);
                                                                                                        parameters.Add("customerPhone", this.            customerPhone
);
                                                                                                        parameters.Add("recordTime", this.            recordTime
);
                                                                                                        parameters.Add("brokerPhone", this.            brokerPhone
);
                                                                                                                                                parameters.Add("attribute2", this.            attribute2
);
                                                                                                                                parameters.Add("brokerName", this.            brokerName
);
                                                                                                                                                parameters.Add("attribute3", this.            attribute3
);
                                                                                                                                parameters.Add("commisionAmt", this.            commisionAmt
);
                                                                                                        parameters.Add("status", this.            status
);
                                                                            }
    }
}





        
 

