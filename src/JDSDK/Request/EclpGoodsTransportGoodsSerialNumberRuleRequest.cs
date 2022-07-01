using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EclpGoodsTransportGoodsSerialNumberRuleRequest : JdRequestBase<EclpGoodsTransportGoodsSerialNumberRuleResponse>
    {
                                                                                                                                              public  		string
              deptNo
 {get; set;}
                                                          
                                                          public  		string
              goodsNo
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              serialNumberLength
 {get; set;}
                                                          
                                                          public  		string
              serialNumberLeftvalue
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              serialNumberLeftLength
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              serialNumberSuffixLength
 {get; set;}
                                                          
                                                          public  		string
              suffixValue
 {get; set;}
                                                          
                                                          public  		string
              type
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              ruleIndex
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              ruleIndexEnd
 {get; set;}
                                                          
                                                          public  		string
              ruleIndexValue
 {get; set;}
                                                          
                                                          public  		string
              manageType
 {get; set;}
                                                          
                                                          public  		string
              sellerSnRuleNo
 {get; set;}
                                                          
                                                          public  		string
              serialRuleType
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.eclp.goods.transportGoodsSerialNumberRule";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("deptNo", this.            deptNo
);
                                                                                                        parameters.Add("goodsNo", this.            goodsNo
);
                                                                                                        parameters.Add("serialNumberLength", this.            serialNumberLength
);
                                                                                                        parameters.Add("serialNumberLeftvalue", this.            serialNumberLeftvalue
);
                                                                                                        parameters.Add("serialNumberLeftLength", this.            serialNumberLeftLength
);
                                                                                                        parameters.Add("serialNumberSuffixLength", this.            serialNumberSuffixLength
);
                                                                                                        parameters.Add("suffixValue", this.            suffixValue
);
                                                                                                        parameters.Add("type", this.            type
);
                                                                                                        parameters.Add("ruleIndex", this.            ruleIndex
);
                                                                                                        parameters.Add("ruleIndexEnd", this.            ruleIndexEnd
);
                                                                                                        parameters.Add("ruleIndexValue", this.            ruleIndexValue
);
                                                                                                        parameters.Add("manageType", this.            manageType
);
                                                                                                        parameters.Add("sellerSnRuleNo", this.            sellerSnRuleNo
);
                                                                                                        parameters.Add("serialRuleType", this.            serialRuleType
);
                                                                                                                            }
    }
}





        
 

