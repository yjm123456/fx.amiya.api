using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EclpPoAddPoOrderRequest : JdRequestBase<EclpPoAddPoOrderResponse>
    {
                                                                                                                                              public  		string
              spPoOrderNo
 {get; set;}
                                                          
                                                          public  		string
              deptNo
 {get; set;}
                                                          
                                                          public  		string
              referenceOrder
 {get; set;}
                                                          
                                                          public  		string
              inboundRemark
 {get; set;}
                                                          
                                                          public  		string
              buyer
 {get; set;}
                                                          
                                                          public  		string
              logicParam
 {get; set;}
                                                          
                                                          public  		string
              whNo
 {get; set;}
                                                          
                                                          public  		string
              supplierNo
 {get; set;}
                                                          
                                                          public  		string
              sellerSaleOrder
 {get; set;}
                                                          
                                                          public  		string
              saleOrder
 {get; set;}
                                                          
                                                          public  		string
              orderMark
 {get; set;}
                                                          
                                                          public  		string
              billType
 {get; set;}
                                                          
                                                          public  		string
              acceptUnQcFlag
 {get; set;}
                                                          
                                                          public  		string
              boxFlag
 {get; set;}
                                                          
                                                          public  		string
              entirePrice
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                            		public  		string
  boxNo {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  boxGoodsNo {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  boxGoodsQty {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  boxSerialNo {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  boxIsvGoodsNo {get; set; }
                                                                                                                                                                                                public  		string
              poReturnMode
 {get; set;}
                                                          
                                                          public  		string
              customsInfo
 {get; set;}
                                                          
                                                          public  		string
              poType
 {get; set;}
                                                          
                                                          public  		string
              billOfLading
 {get; set;}
                                                          
                                                          public  		string
              receiveLevel
 {get; set;}
                                                          
                                                          public  		string
              multiReceivingFlag
 {get; set;}
                                                          
                                                          public  		string
              waybillNo
 {get; set;}
                                                          
                                                          public  		string
              isvOutWarehouse
 {get; set;}
                                                          
                                                          public  		string
              bizType
 {get; set;}
                                                          
                                                          public  		string
              waitBoxDetailFlag
 {get; set;}
                                                          
                                                          public  		string
              unitFlag
 {get; set;}
                                                          
                                                          public  		string
              serialDetailMapJson
 {get; set;}
                                                          
                                                          public  		string
              serialNoScopeMapJson
 {get; set;}
                                                          
                                                          public  		string
              allowLackFlag
 {get; set;}
                                                          
                                                          public  		string
              isUpdate
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                                                             		public  		string
  deptGoodsNo {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  isvGoodsNo {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  numApplication {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  goodsStatus {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  barCodeType {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  sidCheckout {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  unitPrice {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  totalPrice {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  qualityCheckRate {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  batAttrListJson {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  orderLine {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  isvLotattrs {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  checkLotattrs {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  goodsPrice {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  warehousingFlag {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  isvGoodsUnit {get; set; }
                                                                                                                                                                                   public override string ApiName
            {
                get{return "jingdong.eclp.po.addPoOrder";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("spPoOrderNo", this.            spPoOrderNo
);
                                                                                                        parameters.Add("deptNo", this.            deptNo
);
                                                                                                        parameters.Add("referenceOrder", this.            referenceOrder
);
                                                                                                        parameters.Add("inboundRemark", this.            inboundRemark
);
                                                                                                        parameters.Add("buyer", this.            buyer
);
                                                                                                        parameters.Add("logicParam", this.            logicParam
);
                                                                                                        parameters.Add("whNo", this.            whNo
);
                                                                                                        parameters.Add("supplierNo", this.            supplierNo
);
                                                                                                        parameters.Add("sellerSaleOrder", this.            sellerSaleOrder
);
                                                                                                        parameters.Add("saleOrder", this.            saleOrder
);
                                                                                                        parameters.Add("orderMark", this.            orderMark
);
                                                                                                        parameters.Add("billType", this.            billType
);
                                                                                                        parameters.Add("acceptUnQcFlag", this.            acceptUnQcFlag
);
                                                                                                        parameters.Add("boxFlag", this.            boxFlag
);
                                                                                                        parameters.Add("entirePrice", this.            entirePrice
);
                                                                                                                                                                                        parameters.Add("boxNo", this.            boxNo
);
                                                                                                        parameters.Add("boxGoodsNo", this.            boxGoodsNo
);
                                                                                                        parameters.Add("boxGoodsQty", this.            boxGoodsQty
);
                                                                                                        parameters.Add("boxSerialNo", this.            boxSerialNo
);
                                                                                                        parameters.Add("boxIsvGoodsNo", this.            boxIsvGoodsNo
);
                                                                                                                                                        parameters.Add("poReturnMode", this.            poReturnMode
);
                                                                                                        parameters.Add("customsInfo", this.            customsInfo
);
                                                                                                        parameters.Add("poType", this.            poType
);
                                                                                                        parameters.Add("billOfLading", this.            billOfLading
);
                                                                                                        parameters.Add("receiveLevel", this.            receiveLevel
);
                                                                                                        parameters.Add("multiReceivingFlag", this.            multiReceivingFlag
);
                                                                                                        parameters.Add("waybillNo", this.            waybillNo
);
                                                                                                        parameters.Add("isvOutWarehouse", this.            isvOutWarehouse
);
                                                                                                        parameters.Add("bizType", this.            bizType
);
                                                                                                        parameters.Add("waitBoxDetailFlag", this.            waitBoxDetailFlag
);
                                                                                                        parameters.Add("unitFlag", this.            unitFlag
);
                                                                                                        parameters.Add("serialDetailMapJson", this.            serialDetailMapJson
);
                                                                                                        parameters.Add("serialNoScopeMapJson", this.            serialNoScopeMapJson
);
                                                                                                        parameters.Add("allowLackFlag", this.            allowLackFlag
);
                                                                                                        parameters.Add("isUpdate", this.            isUpdate
);
                                                                                                                                                                                                                parameters.Add("deptGoodsNo", this.            deptGoodsNo
);
                                                                                                        parameters.Add("isvGoodsNo", this.            isvGoodsNo
);
                                                                                                        parameters.Add("numApplication", this.            numApplication
);
                                                                                                        parameters.Add("goodsStatus", this.            goodsStatus
);
                                                                                                        parameters.Add("barCodeType", this.            barCodeType
);
                                                                                                        parameters.Add("sidCheckout", this.            sidCheckout
);
                                                                                                        parameters.Add("unitPrice", this.            unitPrice
);
                                                                                                        parameters.Add("totalPrice", this.            totalPrice
);
                                                                                                        parameters.Add("qualityCheckRate", this.            qualityCheckRate
);
                                                                                                        parameters.Add("batAttrListJson", this.            batAttrListJson
);
                                                                                                        parameters.Add("orderLine", this.            orderLine
);
                                                                                                        parameters.Add("isvLotattrs", this.            isvLotattrs
);
                                                                                                        parameters.Add("checkLotattrs", this.            checkLotattrs
);
                                                                                                        parameters.Add("goodsPrice", this.            goodsPrice
);
                                                                                                        parameters.Add("warehousingFlag", this.            warehousingFlag
);
                                                                                                        parameters.Add("isvGoodsUnit", this.            isvGoodsUnit
);
                                                                                                                                                    }
    }
}





        
 

