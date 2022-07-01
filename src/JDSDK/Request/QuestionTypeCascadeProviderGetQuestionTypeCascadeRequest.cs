using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class QuestionTypeCascadeProviderGetQuestionTypeCascadeRequest : JdRequestBase<QuestionTypeCascadeProviderGetQuestionTypeCascadeResponse>
    {
                                                                                  public  		Nullable<int>
              parentId
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              wareId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              afsApplyId
 {get; set;}
                                                          
                                                                                                                      public  		string
              operatorPin
 {get; set;}
                                                          
                                                          public  		string
              operatorNick
 {get; set;}
                                                          
                                                          public  		string
              operatorRemark
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              operatorDate
 {get; set;}
                                                          
                                                          public  		string
              platformSrc
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.QuestionTypeCascadeProvider.getQuestionTypeCascade";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("parentId", this.            parentId
);
                                                                                                        parameters.Add("wareId", this.            wareId
);
                                                                                                        parameters.Add("afsApplyId", this.            afsApplyId
);
                                                                                                                                                parameters.Add("operatorPin", this.            operatorPin
);
                                                                                                        parameters.Add("operatorNick", this.            operatorNick
);
                                                                                                        parameters.Add("operatorRemark", this.            operatorRemark
);
                                                                                                        parameters.Add("operatorDate", this.            operatorDate
);
                                                                                                        parameters.Add("platformSrc", this.            platformSrc
);
                                                                            }
    }
}





        
 

