﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     このコードはツールによって生成されました。
//     ランタイム バージョン: 17.0.0.0
//  
//     このファイルへの変更は、正しくない動作の原因になる可能性があり、
//     コードが再生成されると失われます。
// </auto-generated>
// ------------------------------------------------------------------------------
namespace AdventureWorks.Repository.ProductQuery
{
    using Dapper.QueryTemplate;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
    public partial class SearchAsync : QueryAsyncTemplate<Product>
    {
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("\r\nselect\r\n\tProductID as Id,\r\n\tName\r\nfrom\r\n\tProduct\r\nwhere\r\n\t1 = 1\r\n");
 if (Name is not null) { 
            this.Write("\tand Name = @Name\r\n");
 }
 if (CategoryId is not null) { 
            this.Write("\tand ProductCategoryId = @CategoryId\r\n");
 }
            this.Write("order by\r\n\tId");
            return this.GenerationEnvironment.ToString();
        }
    }
}