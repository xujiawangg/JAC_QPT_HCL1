//=====================================================================================
// All Rights Reserved , Copyright @ HfutIE 2017
// Software Developers @ HfutIE 2017
//=====================================================================================


using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HfutIE.Entity
{
    /// <summary>
    /// CHECK_INFOR_S_P_DETAIL
    /// <author>
    ///		<name>she</name>
    ///		<date>2017.11.12 21:26</date>
    /// </author>
    /// </summary>
    [Description("CHECK_INFOR_S_P_DETAIL")]

    public class CHECK_INFOR_S_P_DETAIL 
    {
        #region ��ȡ/���� �ֶ�ֵ
        /// <summary>
        /// c_i_s_p_key
        /// </summary>
        /// <returns></returns>
        [DisplayName("c_i_s_p_key")]
        public int? c_i_s_p_key { get; set; }
        /// <summary>
        /// CHECK_INFO_KEY
        /// </summary>
        /// <returns></returns>
        [DisplayName("CHECK_INFO_KEY")]
        public int? c_i_key { get; set; }
        /// <summary>
        /// PRODUCT_KEY
        /// </summary>
        /// <returns></returns>
        [DisplayName("PRODUCT_KEY")]
        public string product_key { get; set; }
        /// <summary>
        /// PRODUCT_BORN_CODE
        /// </summary>
        /// <returns></returns>
        [DisplayName("PRODUCT_BORN_CODE")]
        public string product_born_code { get; set; }
        /// <summary>
        /// point_key
        /// </summary>
        /// <returns></returns>
        [DisplayName("point_key")]
        public string point_key { get; set; }
        /// <summary>
        /// PRODUCT_CODE
        /// </summary>
        /// <returns></returns>
        [DisplayName("PRODUCT_CODE")]
        public string product_code { get; set; }
        /// <summary>
        /// PRODUCT_NAME
        /// </summary>
        /// <returns></returns>
        [DisplayName("PRODUCT_NAME")]
        public string product_name { get; set; }
        /// <summary>
        /// WORK_CENTER_KEY
        /// </summary>
        /// <returns></returns>
        [DisplayName("WORK_CENTER_KEY")]
        public string wc_key { get; set; }
        /// <summary>
        /// WORK_CENTER_CODE
        /// </summary>
        /// <returns></returns>
        [DisplayName("WORK_CENTER_CODE")]
        public string wc_code { get; set; }
        /// <summary>
        /// WORK_CENTER_NAME
        /// </summary>
        /// <returns></returns>
        [DisplayName("WORK_CENTER_NAME")]
        public string wc_name { get; set; }
        /// <summary>
        /// PART_KEY
        /// </summary>
        /// <returns></returns>
        [DisplayName("PART_KEY")]
        public string part_key { get; set; }
        /// <summary>
        /// PART_CODE
        /// </summary>
        /// <returns></returns>
        [DisplayName("PART_CODE")]
        public string part_code { get; set; }
        /// <summary>
        /// PART_NAME
        /// </summary>
        /// <returns></returns>
        [DisplayName("PART_NAME")]
        public string part_name { get; set; }
        /// <summary>
        /// PART_BARCODE
        /// </summary>
        /// <returns></returns>
        [DisplayName("PART_BARCODE")]
        public string part_barcode { get; set; }
        /// <summary>
        /// SUPPLIER_KEY
        /// </summary>
        /// <returns></returns>
        [DisplayName("SUPPLIER_KEY")]
        public string supplier_key { get; set; }
        /// <summary>
        /// SUPPLIER_CODE
        /// </summary>
        /// <returns></returns>
        [DisplayName("SUPPLIER_CODE")]
        public string supplier_code { get; set; }
        /// <summary>
        /// SUPPLIER_NAME
        /// </summary>
        /// <returns></returns>
        [DisplayName("SUPPLIER_NAME")]
        public string supplier_name { get; set; }
        /// <summary>
        /// clt_date
        /// </summary>
        /// <returns></returns>
        [DisplayName("clt_date")]
        public DateTime? clt_date { get; set; }
        /// <summary>
        /// clt_result
        /// </summary>
        /// <returns></returns>
        [DisplayName("clt_result")]
        public string clt_result { get; set; }
        /// <summary>
        /// is_clt
        /// </summary>
        /// <returns></returns>
        [DisplayName("is_clt")]
        public string is_clt { get; set; }
        /// <summary>
        /// REMARKS
        /// </summary>
        /// <returns></returns>
        [DisplayName("REMARKS")]
        public string remarks { get; set; }
        /// <summary>
        /// CREATEDATE
        /// </summary>
        /// <returns></returns>
        [DisplayName("CREATEDATE")]
        public DateTime? CreateDate { get; set; }
        /// <summary>
        /// CREATEUSERID
        /// </summary>
        /// <returns></returns>
        [DisplayName("CREATEUSERID")]
        public string CreateUserId { get; set; }
        /// <summary>
        /// CREATEUSERNAME
        /// </summary>
        /// <returns></returns>
        [DisplayName("CREATEUSERNAME")]
        public string CreateUserName { get; set; }
        /// <summary>
        /// MODIFYDATE
        /// </summary>
        /// <returns></returns>
        [DisplayName("MODIFYDATE")]
        public DateTime? ModifyDate { get; set; }
        /// <summary>
        /// MODIFYUSERID
        /// </summary>
        /// <returns></returns>
        [DisplayName("MODIFYUSERID")]
        public string ModifyUserId { get; set; }
        /// <summary>
        /// MODIFYUSERNAME
        /// </summary>
        /// <returns></returns>
        [DisplayName("MODIFYUSERNAME")]
        public string ModifyUserName { get; set; }
        /// <summary>
        /// RESERVE01
        /// </summary>
        /// <returns></returns>
        [DisplayName("RESERVE01")]
        public string reserve1 { get; set; }
        /// <summary>
        /// RESERVE02
        /// </summary>
        /// <returns></returns>
        [DisplayName("RESERVE02")]
        public string reserve2 { get; set; }
        /// <summary>
        /// RESERVE03
        /// </summary>
        /// <returns></returns>
        [DisplayName("RESERVE03")]
        public string reserve3 { get; set; }
        /// <summary>
        /// RESERVE04
        /// </summary>
        /// <returns></returns>
        [DisplayName("RESERVE04")]
        public string reserve4 { get; set; }
        /// <summary>
        /// RESERVE05
        /// </summary>
        /// <returns></returns>
        [DisplayName("RESERVE05")]
        public string reserve5 { get; set; }
        #endregion


    }
}