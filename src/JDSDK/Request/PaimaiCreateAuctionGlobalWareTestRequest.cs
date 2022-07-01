using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class PaimaiCreateAuctionGlobalWareTestRequest : JdRequestBase<PaimaiCreateAuctionGlobalWareTestResponse>
    {
                                                                                                                                              public  		Nullable<long>
              categoryId
 {get; set;}
                                                          
                                                          public  		string
              bail
 {get; set;}
                                                          
                                                          public  		string
              initialPrice
 {get; set;}
                                                          
                                                                                                                            public  		Nullable<int>
              customsBelong
 {get; set;}
                                                          
                                                          public  		string
              commissionRatio
 {get; set;}
                                                          
                                                          public  		string
              name
 {get; set;}
                                                          
                                                          public  		string
              location
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              auctionType
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              auctionWareType
 {get; set;}
                                                          
                                                          public  	    Nullable<double>
              sortWeight
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              deliveryType
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              auctionTimes
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              auctionForm
 {get; set;}
                                                          
                                                          public  		string
              consultant
 {get; set;}
                                                          
                                                          public  		string
              consultTel
 {get; set;}
                                                          
                                                          public  		string
              limitPurchase
 {get; set;}
                                                          
                                                          public  		string
              loanSupport
 {get; set;}
                                                          
                                                          public  		string
              mobileDesc
 {get; set;}
                                                          
                                                          public  		string
              PCDesc
 {get; set;}
                                                          
                                                          public  		string
              reservedPrice
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              incrType
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              incrRangeStart
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              incrRangeEnd
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              delayPeriod
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              reservedPriceRequired
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              is7ToReturn
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              isCertificate
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              isAuthorize
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              isOfflinePreviewCheck
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              stockNum
 {get; set;}
                                                          
                                                          public  		string
              notes
 {get; set;}
                                                          
                                                                                      public  		string
              wareImgs
 {get; set;}
                                                          
                                                          public  		string
              exteriorId
 {get; set;}
                                                          
                                                          public  		string
              evalPrice
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              entrustStartTime
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              entrustEndTime
 {get; set;}
                                                          
                                                          public  		string
              entrustLocation
 {get; set;}
                                                          
                                                          public  		string
              propStr
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              tailOrderPayMode
 {get; set;}
                                                          
                                                          public  		string
              extendParam
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.paimai.createAuctionGlobalWareTest";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("categoryId", this.            categoryId
);
                                                                                                        parameters.Add("bail", this.            bail
);
                                                                                                        parameters.Add("initialPrice", this.            initialPrice
);
                                                                                                                                                                                                        parameters.Add("customsBelong", this.            customsBelong
);
                                                                                                        parameters.Add("commissionRatio", this.            commissionRatio
);
                                                                                                        parameters.Add("name", this.            name
);
                                                                                                        parameters.Add("location", this.            location
);
                                                                                                        parameters.Add("auctionType", this.            auctionType
);
                                                                                                        parameters.Add("auctionWareType", this.            auctionWareType
);
                                                                                                        parameters.Add("sortWeight", this.            sortWeight
);
                                                                                                        parameters.Add("deliveryType", this.            deliveryType
);
                                                                                                        parameters.Add("auctionTimes", this.            auctionTimes
);
                                                                                                        parameters.Add("auctionForm", this.            auctionForm
);
                                                                                                        parameters.Add("consultant", this.            consultant
);
                                                                                                        parameters.Add("consultTel", this.            consultTel
);
                                                                                                        parameters.Add("limitPurchase", this.            limitPurchase
);
                                                                                                        parameters.Add("loanSupport", this.            loanSupport
);
                                                                                                        parameters.Add("mobileDesc", this.            mobileDesc
);
                                                                                                        parameters.Add("PCDesc", this.            PCDesc
);
                                                                                                        parameters.Add("reservedPrice", this.            reservedPrice
);
                                                                                                        parameters.Add("incrType", this.            incrType
);
                                                                                                        parameters.Add("incrRangeStart", this.            incrRangeStart
);
                                                                                                        parameters.Add("incrRangeEnd", this.            incrRangeEnd
);
                                                                                                        parameters.Add("delayPeriod", this.            delayPeriod
);
                                                                                                        parameters.Add("reservedPriceRequired", this.            reservedPriceRequired
);
                                                                                                        parameters.Add("is7ToReturn", this.            is7ToReturn
);
                                                                                                        parameters.Add("isCertificate", this.            isCertificate
);
                                                                                                        parameters.Add("isAuthorize", this.            isAuthorize
);
                                                                                                        parameters.Add("isOfflinePreviewCheck", this.            isOfflinePreviewCheck
);
                                                                                                        parameters.Add("stockNum", this.            stockNum
);
                                                                                                        parameters.Add("notes", this.            notes
);
                                                                                                        parameters.Add("wareImgs", this.            wareImgs
);
                                                                                                        parameters.Add("exteriorId", this.            exteriorId
);
                                                                                                        parameters.Add("evalPrice", this.            evalPrice
);
                                                                                                        parameters.Add("entrustStartTime", this.            entrustStartTime
);
                                                                                                        parameters.Add("entrustEndTime", this.            entrustEndTime
);
                                                                                                        parameters.Add("entrustLocation", this.            entrustLocation
);
                                                                                                        parameters.Add("propStr", this.            propStr
);
                                                                                                        parameters.Add("tailOrderPayMode", this.            tailOrderPayMode
);
                                                                                                        parameters.Add("extendParam", this.            extendParam
);
                                                                            }
    }
}





        
 

