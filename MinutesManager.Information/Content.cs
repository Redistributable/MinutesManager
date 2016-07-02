using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Redefinable.Collections;


namespace Redefinable.Applications.MinutesManager.Information
{
    /// <summary>
    /// 議題あるいは報告内容についてのコレクション機能を提供します。
    /// </summary>
    public class ContentCollection : NativeEventDefinedList<Content>
    {
        // 実装なし
    }

    /// <summary>
    /// １つの議題あるいは報告内容についての情報を取得・設定します。
    /// </summary>
    public class Content
    {
        // 非公開フィールド
        private string title;
        private string text;


        // 公開フィールド
        
        /// <summary>
        /// 件名を取得・設定します。
        /// </summary>
        public string Title
        {
            get { return this.title; }
            set { this.title = value; }
        }

        /// <summary>
        /// 内容を取得・設定します。
        /// </summary>
        public string Text
        {
            get { return this.text; }
            set { this.text = value; }
        }
    }
}
