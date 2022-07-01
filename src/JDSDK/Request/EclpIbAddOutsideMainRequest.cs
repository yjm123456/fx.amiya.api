using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EclpIbAddOutsideMainRequest : JdRequestBase<EclpIbAddOutsideMainResponse>
    {
                                                                                                                                              public  		string
              outsideSource
 {get; set;}
                                                          
                                                          public  		string
              selfLiftCode
 {get; set;}
                                                          
                                                          public  		string
              warehouseNoIn
 {get; set;}
                                                          
                                                          public  		string
              isvOutsideNo
 {get; set;}
                                                          
                                                          public  		string
              shipperNo
 {get; set;}
                                                          
                                                          public  		string
              deptNo
 {get; set;}
                                                          
                                                          public  		string
              warehouseNoOut
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                                                             		public  		string
  goodsNo {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  planNum {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  batAttrListJson {get; set; }
                                                                                                                                                                                   public override string ApiName
            {
                get{return "jingdong.eclp.ib.addOutsideMain";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("outsideSource", this.            outsideSource
);
                                                                                                        parameters.Add("selfLiftCode", this.            selfLiftCode
);
                                                                                                        parameters.Add("warehouseNoIn", this.            warehouseNoIn
);
                                                                                                        parameters.Add("isvOutsideNo", this.            isvOutsideNo
);
                                                                                                        parameters.Add("shipperNo", this.            shipperNo
);
                                                                                                        parameters.Add("deptNo", this.            deptNo
);
                                                                                                        parameters.Add("warehouseNoOut", this.            warehouseNoOut
);
                                                                                                                                                                                                                parameters.Add("goodsNo", this.            goodsNo
);
                                                                                                        parameters.Add("planNum", this.            planNum
);
                                                                                                        parameters.Add("batAttrListJson", this.            batAttrListJson
);
                                                                                                                                                    }
    }
}





        
 

