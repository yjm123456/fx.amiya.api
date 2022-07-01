using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class VcItemNewProductCreateRequest : JdRequestBase<VcItemNewProductCreateResponse>
    {
                                                                                                                   public  		string
                                                                                      applyId
 {get; set;}
                                                                                                                                  
                                                                                                                                                       public  		string
              name
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              cid1
 {get; set;}
                                                          
                                                          public  		Nullable<int>
                                                                                      leafCid
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<int>
                                                                                      brandId
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      zhBrand
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      enBrand
 {get; set;}
                                                                                                                                  
                                                          public  		string
              model
 {get; set;}
                                                          
                                                          public  		string
              tel
 {get; set;}
                                                          
                                                          public  		string
                                                                                      webSite
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      originalPlace
 {get; set;}
                                                                                                                                  
                                                          public  		string
              warranty
 {get; set;}
                                                          
                                                          public  		Nullable<int>
                                                                                      shelfLife
 {get; set;}
                                                                                                                                  
                                                          public  		string
              weight
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              length
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              width
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              height
 {get; set;}
                                                          
                                                          public  		string
                                                                                      marketPrice
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      purchasePrice
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      memberPrice
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      salerCode
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      purchaserCode
 {get; set;}
                                                                                                                                  
                                                          public  		string
              upc
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              packing
 {get; set;}
                                                          
                                                          public  		Nullable<int>
                                                                                      packType
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      skuUnit
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      pkgInfo
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      itemNum
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      introHtml
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      introMobile
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<long>
                                                                                      videoId
 {get; set;}
                                                                                                                                  
                                                                                                                                                                                                                                                                                                                                                                                                                                                   		public  		string
  dangerValue {get; set; }
                                                                                                                                                                                                public  		Nullable<int>
              sysp
 {get; set;}
                                                          
                                                          public  		Nullable<int>
                                                                                      storeProperty
 {get; set;}
                                                                                                                                  
                                                          public  	    Nullable<double>
                                                                                                                      productOilNumber
 {get; set;}
                                                                                                                                                          
                                                          public  		string
                                                                                                                      productOilUnit
 {get; set;}
                                                                                                                                                          
                                                          public  		Nullable<int>
                                                                                      giftsGoods
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      designConcept
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                                                                                      hasTransferElecCode
 {get; set;}
                                                                                                                                                                                  
                                                          public  		string
                                                                                                                      afterSaleDesc
 {get; set;}
                                                                                                                                                          
                                                                                                                                                       public  		string
              wreadme
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                                                                                                                    		public  		string
  propId {get; set; }
                                                                                                                                                                                                                                                                                                                                                                                                                 		public  		string
  propVid {get; set; }
                                                                                                                                                                                                                                                                                                                                                                                                                 		public  		string
  propRemark {get; set; }
                                                                                                                                                                                                                                                                                                                                                                                                                 		public  		string
  propAlias {get; set; }
                                                                                                                                                                                                                                                                                                                                                                                                                 		public  		string
  propValues {get; set; }
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           		public  		string
  extId {get; set; }
                                                                                                                                                                                                                                                                                                                                                                                                                 		public  		string
  extValues {get; set; }
                                                                                                                                                                                                                                                                                                                                                                                                                 		public  		string
  extAlias {get; set; }
                                                                                                                                                                                                                                                                                                                                                                                                                 		public  		string
  extRemark {get; set; }
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  		public  		string
  skuNameGaea {get; set; }
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         		public  		string
  dim1ValGaea {get; set; }
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         		public  		string
  dim1SortGaea {get; set; }
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         		public  		string
  dim2ValGaea {get; set; }
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         		public  		string
  dim2SortGaea {get; set; }
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 		public  		string
  otherSaleAttributeGaea {get; set; }
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         		public  		string
  marketPriceGaea {get; set; }
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         		public  		string
  purchasePriceGaea {get; set; }
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         		public  		string
  memberPriceGaea {get; set; }
                                                                                                                                                                                                                                                                                                                                                                                                                 		public  		string
  weightGaea {get; set; }
                                                                                                                                                                                                                                                                                                                                                                                                                 		public  		string
  lengthGaea {get; set; }
                                                                                                                                                                                                                                                                                                                                                                                                                 		public  		string
  widthGaea {get; set; }
                                                                                                                                                                                                                                                                                                                                                                                                                 		public  		string
  heightGaea {get; set; }
                                                                                                                                                                                                                                                                                                                                                                                                                 		public  		string
  upcGaea {get; set; }
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         		public  		string
  itemNumGaea {get; set; }
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  		public  		string
  type {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  applicant {get; set; }
                                                                                                                                                                                                                                                                                                                                                                                                                 		public  		string
  qcCode {get; set; }
                                                                                                                                                                                                                                                                                                                                                                                                                 		public  		string
  endDate {get; set; }
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         		public  		string
  fileKeyList {get; set; }
                                                                                                                                                  public override string ApiName
            {
                get{return "jingdong.vc.item.newProduct.create";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                parameters.Add("apply_id", this.                                                                                    applyId
);
                                                                                                                                                                                                parameters.Add("name", this.            name
);
                                                                                                        parameters.Add("cid1", this.            cid1
);
                                                                                                        parameters.Add("leaf_cid", this.                                                                                    leafCid
);
                                                                                                        parameters.Add("brand_id", this.                                                                                    brandId
);
                                                                                                        parameters.Add("zh_brand", this.                                                                                    zhBrand
);
                                                                                                        parameters.Add("en_brand", this.                                                                                    enBrand
);
                                                                                                        parameters.Add("model", this.            model
);
                                                                                                        parameters.Add("tel", this.            tel
);
                                                                                                        parameters.Add("web_site", this.                                                                                    webSite
);
                                                                                                        parameters.Add("original_place", this.                                                                                    originalPlace
);
                                                                                                        parameters.Add("warranty", this.            warranty
);
                                                                                                        parameters.Add("shelf_life", this.                                                                                    shelfLife
);
                                                                                                        parameters.Add("weight", this.            weight
);
                                                                                                        parameters.Add("length", this.            length
);
                                                                                                        parameters.Add("width", this.            width
);
                                                                                                        parameters.Add("height", this.            height
);
                                                                                                        parameters.Add("market_price", this.                                                                                    marketPrice
);
                                                                                                        parameters.Add("purchase_price", this.                                                                                    purchasePrice
);
                                                                                                        parameters.Add("member_price", this.                                                                                    memberPrice
);
                                                                                                        parameters.Add("saler_code", this.                                                                                    salerCode
);
                                                                                                        parameters.Add("purchaser_code", this.                                                                                    purchaserCode
);
                                                                                                        parameters.Add("upc", this.            upc
);
                                                                                                        parameters.Add("packing", this.            packing
);
                                                                                                        parameters.Add("pack_type", this.                                                                                    packType
);
                                                                                                        parameters.Add("sku_unit", this.                                                                                    skuUnit
);
                                                                                                        parameters.Add("pkg_info", this.                                                                                    pkgInfo
);
                                                                                                        parameters.Add("item_num", this.                                                                                    itemNum
);
                                                                                                        parameters.Add("intro_html", this.                                                                                    introHtml
);
                                                                                                        parameters.Add("intro_mobile", this.                                                                                    introMobile
);
                                                                                                        parameters.Add("video_id", this.                                                                                    videoId
);
                                                                                                                                                parameters.Add("danger_value", this.                                                                                    dangerValue
);
                                                                                                                                parameters.Add("sysp", this.            sysp
);
                                                                                                        parameters.Add("store_property", this.                                                                                    storeProperty
);
                                                                                                        parameters.Add("product_oil_number", this.                                                                                                                    productOilNumber
);
                                                                                                        parameters.Add("product_oil_unit", this.                                                                                                                    productOilUnit
);
                                                                                                        parameters.Add("gifts_goods", this.                                                                                    giftsGoods
);
                                                                                                        parameters.Add("design_concept", this.                                                                                    designConcept
);
                                                                                                        parameters.Add("has_transfer_elec_code", this.                                                                                                                                                    hasTransferElecCode
);
                                                                                                        parameters.Add("after_sale_desc", this.                                                                                                                    afterSaleDesc
);
                                                                                                                                                                        parameters.Add("wreadme", this.            wreadme
);
                                                                                                                                                                                        parameters.Add("prop_id", this.                                                                                    propId
);
                                                                                                        parameters.Add("prop_vid", this.                                                                                    propVid
);
                                                                                                        parameters.Add("prop_remark", this.                                                                                    propRemark
);
                                                                                                        parameters.Add("prop_alias", this.                                                                                    propAlias
);
                                                                                                        parameters.Add("prop_values", this.                                                                                    propValues
);
                                                                                                                                                                                                                                                                parameters.Add("ext_id", this.                                                                                    extId
);
                                                                                                        parameters.Add("ext_values", this.                                                                                    extValues
);
                                                                                                        parameters.Add("ext_alias", this.                                                                                    extAlias
);
                                                                                                        parameters.Add("ext_remark", this.                                                                                    extRemark
);
                                                                                                                                                                                                                                        parameters.Add("sku_name_gaea", this.                                                                                                                    skuNameGaea
);
                                                                                                        parameters.Add("dim1_val_gaea", this.                                                                                                                    dim1ValGaea
);
                                                                                                        parameters.Add("dim1_sort_gaea", this.                                                                                                                    dim1SortGaea
);
                                                                                                        parameters.Add("dim2_val_gaea", this.                                                                                                                    dim2ValGaea
);
                                                                                                        parameters.Add("dim2_sort_gaea", this.                                                                                                                    dim2SortGaea
);
                                                                                                        parameters.Add("other_sale_attribute_gaea", this.                                                                                                                                                    otherSaleAttributeGaea
);
                                                                                                        parameters.Add("market_price_gaea", this.                                                                                                                    marketPriceGaea
);
                                                                                                        parameters.Add("purchase_price_gaea", this.                                                                                                                    purchasePriceGaea
);
                                                                                                        parameters.Add("member_price_gaea", this.                                                                                                                    memberPriceGaea
);
                                                                                                        parameters.Add("weight_gaea", this.                                                                                    weightGaea
);
                                                                                                        parameters.Add("length_gaea", this.                                                                                    lengthGaea
);
                                                                                                        parameters.Add("width_gaea", this.                                                                                    widthGaea
);
                                                                                                        parameters.Add("height_gaea", this.                                                                                    heightGaea
);
                                                                                                        parameters.Add("upc_gaea", this.                                                                                    upcGaea
);
                                                                                                        parameters.Add("item_num_gaea", this.                                                                                                                    itemNumGaea
);
                                                                                                                                                                                                                                        parameters.Add("type", this.            type
);
                                                                                                        parameters.Add("applicant", this.            applicant
);
                                                                                                        parameters.Add("qc_code", this.                                                                                    qcCode
);
                                                                                                        parameters.Add("end_date", this.                                                                                    endDate
);
                                                                                                        parameters.Add("file_key_list", this.                                                                                                                    fileKeyList
);
                                                                                                    }
    }
}





        
 

