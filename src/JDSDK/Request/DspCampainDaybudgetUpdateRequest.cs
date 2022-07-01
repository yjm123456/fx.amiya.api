using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class DspCampainDaybudgetUpdateRequest : JdRequestBase<DspCampainDaybudgetUpdateResponse>
    {
                                                                                                                                              public  		Nullable<long>
              id
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              dayBudget
 {get; set;}
                                                          
                                                                                                                                                public override string ApiName
            {
                get{return "jingdong.dsp.campain.daybudget.update";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("id", this.            id
);
                                                                                                        parameters.Add("dayBudget", this.            dayBudget
);
                                                                                                                                                                                                                            }
    }
}





        
 

