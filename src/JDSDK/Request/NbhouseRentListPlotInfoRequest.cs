using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class NbhouseRentListPlotInfoRequest : JdRequestBase<NbhouseRentListPlotInfoResponse>
    {
                                                                                                                                              public  	    Nullable<double>
              lat
 {get; set;}
                                                          
                                                          public  	    Nullable<double>
              lon
 {get; set;}
                                                          
                                                          public  	    Nullable<double>
              distance
 {get; set;}
                                                          
                                                          public  		string
              plotName
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              plotCode
 {get; set;}
                                                          
                                                          public  		string
              matchName
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              currentPage
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageSize
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.nbhouse.rent.listPlotInfo";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("lat", this.            lat
);
                                                                                                        parameters.Add("lon", this.            lon
);
                                                                                                        parameters.Add("distance", this.            distance
);
                                                                                                        parameters.Add("plotName", this.            plotName
);
                                                                                                        parameters.Add("plotCode", this.            plotCode
);
                                                                                                        parameters.Add("matchName", this.            matchName
);
                                                                                                        parameters.Add("currentPage", this.            currentPage
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                                            }
    }
}





        
 

