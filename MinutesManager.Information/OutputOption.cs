using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Redefinable.Applications.MinutesManager.Information
{
    /// <summary>
    /// Recordを実際のテキストデータへ出力する際の変換についての設定を格納します。
    /// </summary>
    public struct OutputOption
    {
        // 非公開フィールド
        private string titleFormat;
        

        // 公開フィールド
        
        /// <summary>
        /// 議事録のタイトルのフォーマットを決定します。
        /// </summary>
        public string TitleFormat
        {
            get { return this.titleFormat; }
            set { this.titleFormat = value; }
        }
    }
}
