using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class LdopCenterApiEportdeclareRequest : JdRequestBase<LdopCenterApiEportdeclareResponse>
    {
                                                                                                                                              public  		string
              platformId
 {get; set;}
                                                          
                                                          public  		string
              platformName
 {get; set;}
                                                          
                                                          public  		string
              appType
 {get; set;}
                                                          
                                                          public  		string
              logisticsNo
 {get; set;}
                                                          
                                                          public  		string
              billSerialNo
 {get; set;}
                                                          
                                                          public  		string
              billNo
 {get; set;}
                                                          
                                                          public  		string
              freight
 {get; set;}
                                                          
                                                          public  		string
              insuredFee
 {get; set;}
                                                          
                                                          public  		string
              netWeight
 {get; set;}
                                                          
                                                          public  		string
              weight
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              packNo
 {get; set;}
                                                          
                                                          public  		string
              worth
 {get; set;}
                                                          
                                                          public  		string
              goodsName
 {get; set;}
                                                          
                                                          public  		string
              orderNo
 {get; set;}
                                                          
                                                          public  		string
              shipper
 {get; set;}
                                                          
                                                          public  		string
              shipperAddress
 {get; set;}
                                                          
                                                          public  		string
              shipperTelephone
 {get; set;}
                                                          
                                                          public  		string
              shipperCountry
 {get; set;}
                                                          
                                                          public  		string
              consigneeCountry
 {get; set;}
                                                          
                                                          public  		string
              consigneeProvince
 {get; set;}
                                                          
                                                          public  		string
              consigneeCity
 {get; set;}
                                                          
                                                          public  		string
              consigneeDistrict
 {get; set;}
                                                          
                                                          public  		string
              consingee
 {get; set;}
                                                          
                                                          public  		string
              consigneeAddress
 {get; set;}
                                                          
                                                          public  		string
              consigneeTelephone
 {get; set;}
                                                          
                                                          public  		string
              buyerIdType
 {get; set;}
                                                          
                                                          public  		string
              buyerIdNumber
 {get; set;}
                                                          
                                                          public  		string
              customsId
 {get; set;}
                                                          
                                                          public  		string
              customsCode
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.ldop.center.api.eportdeclare";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("platformId", this.            platformId
);
                                                                                                        parameters.Add("platformName", this.            platformName
);
                                                                                                        parameters.Add("appType", this.            appType
);
                                                                                                        parameters.Add("logisticsNo", this.            logisticsNo
);
                                                                                                        parameters.Add("billSerialNo", this.            billSerialNo
);
                                                                                                        parameters.Add("billNo", this.            billNo
);
                                                                                                        parameters.Add("freight", this.            freight
);
                                                                                                        parameters.Add("insuredFee", this.            insuredFee
);
                                                                                                        parameters.Add("netWeight", this.            netWeight
);
                                                                                                        parameters.Add("weight", this.            weight
);
                                                                                                        parameters.Add("packNo", this.            packNo
);
                                                                                                        parameters.Add("worth", this.            worth
);
                                                                                                        parameters.Add("goodsName", this.            goodsName
);
                                                                                                        parameters.Add("orderNo", this.            orderNo
);
                                                                                                        parameters.Add("shipper", this.            shipper
);
                                                                                                        parameters.Add("shipperAddress", this.            shipperAddress
);
                                                                                                        parameters.Add("shipperTelephone", this.            shipperTelephone
);
                                                                                                        parameters.Add("shipperCountry", this.            shipperCountry
);
                                                                                                        parameters.Add("consigneeCountry", this.            consigneeCountry
);
                                                                                                        parameters.Add("consigneeProvince", this.            consigneeProvince
);
                                                                                                        parameters.Add("consigneeCity", this.            consigneeCity
);
                                                                                                        parameters.Add("consigneeDistrict", this.            consigneeDistrict
);
                                                                                                        parameters.Add("consingee", this.            consingee
);
                                                                                                        parameters.Add("consigneeAddress", this.            consigneeAddress
);
                                                                                                        parameters.Add("consigneeTelephone", this.            consigneeTelephone
);
                                                                                                        parameters.Add("buyerIdType", this.            buyerIdType
);
                                                                                                        parameters.Add("buyerIdNumber", this.            buyerIdNumber
);
                                                                                                        parameters.Add("customsId", this.            customsId
);
                                                                                                        parameters.Add("customsCode", this.            customsCode
);
                                                                            }
    }
}





        
 

