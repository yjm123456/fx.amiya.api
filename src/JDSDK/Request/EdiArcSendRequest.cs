using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EdiArcSendRequest : JdRequestBase<EdiArcSendResponse>
    {
                                                                                                                                              public  		string
              vendorName
 {get; set;}
                                                          
                                                          public  		string
              payableAccountId
 {get; set;}
                                                          
                                                          public  		string
              billType
 {get; set;}
                                                          
                                                          public  		string
              billNo
 {get; set;}
                                                          
                                                          public  		string
              poNo
 {get; set;}
                                                          
                                                          public  		string
              respond
 {get; set;}
                                                          
                                                          public  		string
              amount
 {get; set;}
                                                          
                                                                                           public  		string
              vendorCode
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.edi.arc.send";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("vendorName", this.            vendorName
);
                                                                                                        parameters.Add("payableAccountId", this.            payableAccountId
);
                                                                                                        parameters.Add("billType", this.            billType
);
                                                                                                        parameters.Add("billNo", this.            billNo
);
                                                                                                        parameters.Add("poNo", this.            poNo
);
                                                                                                        parameters.Add("respond", this.            respond
);
                                                                                                        parameters.Add("amount", this.            amount
);
                                                                                                                                                        parameters.Add("vendorCode", this.            vendorCode
);
                                                                            }
    }
}





        
 

