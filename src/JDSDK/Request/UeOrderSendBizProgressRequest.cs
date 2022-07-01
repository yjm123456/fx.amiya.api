using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class UeOrderSendBizProgressRequest : JdRequestBase<UeOrderSendBizProgressResponse>
    {
                                                                                                                                              public  		string
              sendDate
 {get; set;}
                                                          
                                                          public  		string
              appId
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                            		public  		string
  engineerName {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  netWorkContactMan {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  engineerCode {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  netWorkTel {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  netWorkCode {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  netWorkAddress {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		Nullable<DateTime>
  sendNetWorkDate {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  engineerMobile {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  sendEngineeDate {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  orderNo {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  netWorkName {get; set; }
                                                                                                                                                                                                public  		string
              sendBy
 {get; set;}
                                                          
                                                          public  		string
              type
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.ue.order.sendBizProgress";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("sendDate", this.            sendDate
);
                                                                                                        parameters.Add("appId", this.            appId
);
                                                                                                                                                                                        parameters.Add("engineerName", this.            engineerName
);
                                                                                                        parameters.Add("netWorkContactMan", this.            netWorkContactMan
);
                                                                                                        parameters.Add("engineerCode", this.            engineerCode
);
                                                                                                        parameters.Add("netWorkTel", this.            netWorkTel
);
                                                                                                        parameters.Add("netWorkCode", this.            netWorkCode
);
                                                                                                        parameters.Add("netWorkAddress", this.            netWorkAddress
);
                                                                                                        parameters.Add("sendNetWorkDate", this.            sendNetWorkDate
);
                                                                                                        parameters.Add("engineerMobile", this.            engineerMobile
);
                                                                                                        parameters.Add("sendEngineeDate", this.            sendEngineeDate
);
                                                                                                        parameters.Add("orderNo", this.            orderNo
);
                                                                                                        parameters.Add("netWorkName", this.            netWorkName
);
                                                                                                                                                        parameters.Add("sendBy", this.            sendBy
);
                                                                                                        parameters.Add("type", this.            type
);
                                                                            }
    }
}





        
 

