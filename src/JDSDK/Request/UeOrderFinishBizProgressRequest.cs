using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class UeOrderFinishBizProgressRequest : JdRequestBase<UeOrderFinishBizProgressResponse>
    {
                                                                                                                                              public  		string
              appId
 {get; set;}
                                                          
                                                          public  		string
              barcode2
 {get; set;}
                                                          
                                                          public  		string
              pic10
 {get; set;}
                                                          
                                                          public  		string
              barcode1
 {get; set;}
                                                          
                                                          public  		string
              failureReason
 {get; set;}
                                                          
                                                          public  		string
              dealRemark
 {get; set;}
                                                          
                                                          public  		string
              createBy
 {get; set;}
                                                          
                                                          public  		string
              pic1
 {get; set;}
                                                          
                                                          public  		string
              failureName
 {get; set;}
                                                          
                                                          public  		string
              operateDate
 {get; set;}
                                                          
                                                          public  		string
              orderNo
 {get; set;}
                                                          
                                                          public  		string
              fixMethod
 {get; set;}
                                                          
                                                          public  		string
              pic9
 {get; set;}
                                                          
                                                          public  		string
              pic8
 {get; set;}
                                                          
                                                          public  		string
              pic7
 {get; set;}
                                                          
                                                          public  		string
              pic6
 {get; set;}
                                                          
                                                          public  		string
              dealResult
 {get; set;}
                                                          
                                                          public  		string
              pic5
 {get; set;}
                                                          
                                                          public  		string
              pic4
 {get; set;}
                                                          
                                                          public  		string
              usedMaterial
 {get; set;}
                                                          
                                                          public  		string
              pic3
 {get; set;}
                                                          
                                                          public  		string
              pic2
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.ue.order.finishBizProgress";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("appId", this.            appId
);
                                                                                                        parameters.Add("barcode2", this.            barcode2
);
                                                                                                        parameters.Add("pic10", this.            pic10
);
                                                                                                        parameters.Add("barcode1", this.            barcode1
);
                                                                                                        parameters.Add("failureReason", this.            failureReason
);
                                                                                                        parameters.Add("dealRemark", this.            dealRemark
);
                                                                                                        parameters.Add("createBy", this.            createBy
);
                                                                                                        parameters.Add("pic1", this.            pic1
);
                                                                                                        parameters.Add("failureName", this.            failureName
);
                                                                                                        parameters.Add("operateDate", this.            operateDate
);
                                                                                                        parameters.Add("orderNo", this.            orderNo
);
                                                                                                        parameters.Add("fixMethod", this.            fixMethod
);
                                                                                                        parameters.Add("pic9", this.            pic9
);
                                                                                                        parameters.Add("pic8", this.            pic8
);
                                                                                                        parameters.Add("pic7", this.            pic7
);
                                                                                                        parameters.Add("pic6", this.            pic6
);
                                                                                                        parameters.Add("dealResult", this.            dealResult
);
                                                                                                        parameters.Add("pic5", this.            pic5
);
                                                                                                        parameters.Add("pic4", this.            pic4
);
                                                                                                        parameters.Add("usedMaterial", this.            usedMaterial
);
                                                                                                        parameters.Add("pic3", this.            pic3
);
                                                                                                        parameters.Add("pic2", this.            pic2
);
                                                                            }
    }
}





        
 

