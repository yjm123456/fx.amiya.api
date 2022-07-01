using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EclpInsideAddUlOrderRequest : JdRequestBase<EclpInsideAddUlOrderResponse>
    {
                                                                                                                                              public  		string
              outUlNo
 {get; set;}
                                                          
                                                          public  		string
              sellerNo
 {get; set;}
                                                          
                                                          public  		string
              warehouseNo
 {get; set;}
                                                          
                                                          public  		string
              deptNo
 {get; set;}
                                                          
                                                          public  		string
              deliveryMode
 {get; set;}
                                                          
                                                          public  		string
              ulType
 {get; set;}
                                                          
                                                          public  		string
              allowReturnDest
 {get; set;}
                                                          
                                                          public  		string
              allowLackDest
 {get; set;}
                                                          
                                                          public  		string
              destMethod
 {get; set;}
                                                          
                                                          public  		string
              destReason
 {get; set;}
                                                          
                                                          public  		string
              destCompNo
 {get; set;}
                                                          
                                                          public  		string
              receiver
 {get; set;}
                                                          
                                                          public  		string
              receiverPhone
 {get; set;}
                                                          
                                                          public  		string
              email
 {get; set;}
                                                          
                                                          public  		string
              province
 {get; set;}
                                                          
                                                          public  		string
              city
 {get; set;}
                                                          
                                                          public  		string
              county
 {get; set;}
                                                          
                                                          public  		string
              town
 {get; set;}
                                                          
                                                          public  		string
              address
 {get; set;}
                                                          
                                                          public  		string
              backEmail
 {get; set;}
                                                          
                                                          public  		string
              createUser
 {get; set;}
                                                          
                                                          public  		string
              createTime
 {get; set;}
                                                          
                                                          public  		string
              remark
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                                                             		public  		string
  orderLine {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  goodsNo {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  goodsName {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  planQty {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  goodsLevel {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  ulItemBatchRequest {get; set; }
                                                                                                                                                                                   public override string ApiName
            {
                get{return "jingdong.eclp.inside.addUlOrder";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("outUlNo", this.            outUlNo
);
                                                                                                        parameters.Add("sellerNo", this.            sellerNo
);
                                                                                                        parameters.Add("warehouseNo", this.            warehouseNo
);
                                                                                                        parameters.Add("deptNo", this.            deptNo
);
                                                                                                        parameters.Add("deliveryMode", this.            deliveryMode
);
                                                                                                        parameters.Add("ulType", this.            ulType
);
                                                                                                        parameters.Add("allowReturnDest", this.            allowReturnDest
);
                                                                                                        parameters.Add("allowLackDest", this.            allowLackDest
);
                                                                                                        parameters.Add("destMethod", this.            destMethod
);
                                                                                                        parameters.Add("destReason", this.            destReason
);
                                                                                                        parameters.Add("destCompNo", this.            destCompNo
);
                                                                                                        parameters.Add("receiver", this.            receiver
);
                                                                                                        parameters.Add("receiverPhone", this.            receiverPhone
);
                                                                                                        parameters.Add("email", this.            email
);
                                                                                                        parameters.Add("province", this.            province
);
                                                                                                        parameters.Add("city", this.            city
);
                                                                                                        parameters.Add("county", this.            county
);
                                                                                                        parameters.Add("town", this.            town
);
                                                                                                        parameters.Add("address", this.            address
);
                                                                                                        parameters.Add("backEmail", this.            backEmail
);
                                                                                                        parameters.Add("createUser", this.            createUser
);
                                                                                                        parameters.Add("createTime", this.            createTime
);
                                                                                                        parameters.Add("remark", this.            remark
);
                                                                                                                                                                                                                parameters.Add("orderLine", this.            orderLine
);
                                                                                                        parameters.Add("goodsNo", this.            goodsNo
);
                                                                                                        parameters.Add("goodsName", this.            goodsName
);
                                                                                                        parameters.Add("planQty", this.            planQty
);
                                                                                                        parameters.Add("goodsLevel", this.            goodsLevel
);
                                                                                                        parameters.Add("ulItemBatchRequest", this.            ulItemBatchRequest
);
                                                                                                                                                    }
    }
}





        
 

