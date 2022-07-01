using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class UeOrderNewFinishRequest : JdRequestBase<UeOrderNewFinishResponse>
    {
                                                                                                                                              public  		string
              barcode2
 {get; set;}
                                                          
                                                          public  		string
              barcode1
 {get; set;}
                                                          
                                                          public  		string
              failureReason
 {get; set;}
                                                          
                                                          public  		string
              siteName
 {get; set;}
                                                          
                                                          public  		string
              failureName
 {get; set;}
                                                          
                                                          public  		string
              pic1
 {get; set;}
                                                          
                                                          public  		string
              venderCode
 {get; set;}
                                                          
                                                          public  		string
              pic2
 {get; set;}
                                                          
                                                          public  		string
              pic3
 {get; set;}
                                                          
                                                          public  		string
              dealRemark
 {get; set;}
                                                          
                                                          public  		string
              pic4
 {get; set;}
                                                          
                                                          public  		string
              fixMethod
 {get; set;}
                                                          
                                                          public  		string
              createBy
 {get; set;}
                                                          
                                                          public  		string
              appid
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              dealResult
 {get; set;}
                                                          
                                                          public  		string
              settleCode
 {get; set;}
                                                          
                                                          public  		string
              inSkuSn
 {get; set;}
                                                          
                                                          public  		string
              outSkuSn
 {get; set;}
                                                          
                                                          public  		string
              orderNo
 {get; set;}
                                                          
                                                          public  		string
              detecDetail
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              detecResult
 {get; set;}
                                                          
                                                          public  		string
              detecPic
 {get; set;}
                                                          
                                                          public  		string
              installSituation
 {get; set;}
                                                          
                                                          public  		string
              invoiceSituation
 {get; set;}
                                                          
                                                          public  		string
              warrantyCard
 {get; set;}
                                                          
                                                          public  		string
              outRepair
 {get; set;}
                                                          
                                                          public  		string
              chargeAmount
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.ue.order.new.finish";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("barcode2", this.            barcode2
);
                                                                                                        parameters.Add("barcode1", this.            barcode1
);
                                                                                                        parameters.Add("failureReason", this.            failureReason
);
                                                                                                        parameters.Add("siteName", this.            siteName
);
                                                                                                        parameters.Add("failureName", this.            failureName
);
                                                                                                        parameters.Add("pic1", this.            pic1
);
                                                                                                        parameters.Add("venderCode", this.            venderCode
);
                                                                                                        parameters.Add("pic2", this.            pic2
);
                                                                                                        parameters.Add("pic3", this.            pic3
);
                                                                                                        parameters.Add("dealRemark", this.            dealRemark
);
                                                                                                        parameters.Add("pic4", this.            pic4
);
                                                                                                        parameters.Add("fixMethod", this.            fixMethod
);
                                                                                                        parameters.Add("createBy", this.            createBy
);
                                                                                                        parameters.Add("appid", this.            appid
);
                                                                                                        parameters.Add("dealResult", this.            dealResult
);
                                                                                                        parameters.Add("settleCode", this.            settleCode
);
                                                                                                        parameters.Add("inSkuSn", this.            inSkuSn
);
                                                                                                        parameters.Add("outSkuSn", this.            outSkuSn
);
                                                                                                        parameters.Add("orderNo", this.            orderNo
);
                                                                                                        parameters.Add("detecDetail", this.            detecDetail
);
                                                                                                        parameters.Add("detecResult", this.            detecResult
);
                                                                                                        parameters.Add("detecPic", this.            detecPic
);
                                                                                                        parameters.Add("installSituation", this.            installSituation
);
                                                                                                        parameters.Add("invoiceSituation", this.            invoiceSituation
);
                                                                                                        parameters.Add("warrantyCard", this.            warrantyCard
);
                                                                                                        parameters.Add("outRepair", this.            outRepair
);
                                                                                                        parameters.Add("chargeAmount", this.            chargeAmount
);
                                                                            }
    }
}





        
 

