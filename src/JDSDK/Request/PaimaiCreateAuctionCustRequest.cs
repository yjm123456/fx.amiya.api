using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class PaimaiCreateAuctionCustRequest : JdRequestBase<PaimaiCreateAuctionCustResponse>
    {
                                                                                                                                              public  		string
              name
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              categoryId
 {get; set;}
                                                          
                                                          public  		string
              summary
 {get; set;}
                                                          
                                                          public  		string
              thumbTopUrl
 {get; set;}
                                                          
                                                          public  		string
              thumbEntranceUrl
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              auctionCustType
 {get; set;}
                                                          
                                                                                                                            public  		Nullable<int>
              auctionForm
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              sortType
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              startTime
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              endTime
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              auctionType
 {get; set;}
                                                          
                                                          public  		string
              paimaiIds
 {get; set;}
                                                          
                                                          public  		string
              exteriorId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              biddingPeriod
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.paimai.createAuctionCust";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("name", this.            name
);
                                                                                                        parameters.Add("categoryId", this.            categoryId
);
                                                                                                        parameters.Add("summary", this.            summary
);
                                                                                                        parameters.Add("thumbTopUrl", this.            thumbTopUrl
);
                                                                                                        parameters.Add("thumbEntranceUrl", this.            thumbEntranceUrl
);
                                                                                                        parameters.Add("auctionCustType", this.            auctionCustType
);
                                                                                                                                                                                                        parameters.Add("auctionForm", this.            auctionForm
);
                                                                                                        parameters.Add("sortType", this.            sortType
);
                                                                                                        parameters.Add("startTime", this.            startTime
);
                                                                                                        parameters.Add("endTime", this.            endTime
);
                                                                                                        parameters.Add("auctionType", this.            auctionType
);
                                                                                                        parameters.Add("paimaiIds", this.            paimaiIds
);
                                                                                                        parameters.Add("exteriorId", this.            exteriorId
);
                                                                                                        parameters.Add("biddingPeriod", this.            biddingPeriod
);
                                                                            }
    }
}





        
 

