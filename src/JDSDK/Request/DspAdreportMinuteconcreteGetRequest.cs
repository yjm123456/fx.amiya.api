using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class DspAdreportMinuteconcreteGetRequest : JdRequestBase<DspAdreportMinuteconcreteGetResponse>
    {
                                                                                                                                              public  		string
              dimension
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              id
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              putType
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              startMinute
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              endMinute
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                           		public  		string
  days {get; set; }
                                                                                                                                                                                                                                                                  public  		Nullable<int>
              granularity
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.dsp.adreport.minuteconcrete.get";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("dimension", this.            dimension
);
                                                                                                        parameters.Add("id", this.            id
);
                                                                                                        parameters.Add("putType", this.            putType
);
                                                                                                        parameters.Add("startMinute", this.            startMinute
);
                                                                                                        parameters.Add("endMinute", this.            endMinute
);
                                                                                                                                                parameters.Add("days", this.            days
);
                                                                                                                                                                                                                                parameters.Add("granularity", this.            granularity
);
                                                                            }
    }
}





        
 

