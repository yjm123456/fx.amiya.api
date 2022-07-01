using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EclpOrderAddDeclareOrderCustomsRequest : JdRequestBase<EclpOrderAddDeclareOrderCustomsResponse>
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
                                                          
                                                          public  	    Nullable<double>
              freight
 {get; set;}
                                                          
                                                          public  	    Nullable<double>
              insuredFee
 {get; set;}
                                                          
                                                          public  	    Nullable<double>
              netWeight
 {get; set;}
                                                          
                                                          public  	    Nullable<double>
              weight
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              packNo
 {get; set;}
                                                          
                                                          public  	    Nullable<double>
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
                                                          
                                                          public  		string
              deptNo
 {get; set;}
                                                          
                                                          public  		string
              isvSource
 {get; set;}
                                                          
                                                          public  		string
              pattern
 {get; set;}
                                                          
                                                          public  		string
              isvUUID
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              platformType
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              salesPlatformCreateTime
 {get; set;}
                                                          
                                                          public  		string
              postType
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              istax
 {get; set;}
                                                          
                                                          public  		string
              logisticsCode
 {get; set;}
                                                          
                                                          public  		string
              logisticsName
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              isDelivery
 {get; set;}
                                                          
                                                          public  		string
              ebpCode
 {get; set;}
                                                          
                                                          public  		string
              ebpName
 {get; set;}
                                                          
                                                          public  		string
              ebcCode
 {get; set;}
                                                          
                                                          public  		string
              ebcName
 {get; set;}
                                                          
                                                          public  		string
              ebpCiqCode
 {get; set;}
                                                          
                                                          public  		string
              ebpCiqName
 {get; set;}
                                                          
                                                          public  		string
              ebcCiqCode
 {get; set;}
                                                          
                                                          public  		string
              ebcCiqName
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.eclp.order.addDeclareOrderCustoms";}
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
                                                                                                        parameters.Add("deptNo", this.            deptNo
);
                                                                                                        parameters.Add("isvSource", this.            isvSource
);
                                                                                                        parameters.Add("pattern", this.            pattern
);
                                                                                                        parameters.Add("isvUUID", this.            isvUUID
);
                                                                                                        parameters.Add("platformType", this.            platformType
);
                                                                                                        parameters.Add("salesPlatformCreateTime", this.            salesPlatformCreateTime
);
                                                                                                        parameters.Add("postType", this.            postType
);
                                                                                                        parameters.Add("istax", this.            istax
);
                                                                                                        parameters.Add("logisticsCode", this.            logisticsCode
);
                                                                                                        parameters.Add("logisticsName", this.            logisticsName
);
                                                                                                        parameters.Add("isDelivery", this.            isDelivery
);
                                                                                                        parameters.Add("ebpCode", this.            ebpCode
);
                                                                                                        parameters.Add("ebpName", this.            ebpName
);
                                                                                                        parameters.Add("ebcCode", this.            ebcCode
);
                                                                                                        parameters.Add("ebcName", this.            ebcName
);
                                                                                                        parameters.Add("ebpCiqCode", this.            ebpCiqCode
);
                                                                                                        parameters.Add("ebpCiqName", this.            ebpCiqName
);
                                                                                                        parameters.Add("ebcCiqCode", this.            ebcCiqCode
);
                                                                                                        parameters.Add("ebcCiqName", this.            ebcCiqName
);
                                                                                                                            }
    }
}





        
 

