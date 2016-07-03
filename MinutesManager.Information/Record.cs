using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Redefinable.Applications.MinutesManager.Information
{
    /// <summary>
    /// 議事録についての情報を格納します。
    /// </summary>
    public class Record
    {
        // 非公開フィールド
        private DateTime dateTime;
        private SectionCollection sections;
        private bool isReadOnly;
        private OutputOption outputOption;

        
        // 公開フィールド

        /// <summary>
        /// この議事録の日時を取得・設定します。IsReadOnlyがtrueの場合、設定操作が無効になります。
        /// </summary>
        public DateTime DateTime
        {
            get { return this._getDateTime(); }
            set { this._setDateTime(value); }
        }

        /// <summary>
        /// この議事録のタイトルを取得します。形式はOutputOptionにより決定されます。
        /// </summary>
        public string Title
        {
            get { return this._getTitle(); }
        }

        /// <summary>
        /// この議事録に含まれるセクションのコレクションを取得します。IsReadOnlyがtrueの場合、複製されたコレクションのインスタンスを取得します。
        /// </summary>
        public SectionCollection Sections
        {
            get { return this._getSections(); }
        }


        // コンストラクタ
        
        /// <summary>
        /// 日時と出力オプションとセクションのコレクションを指定して、新しいRecordクラスのインスタンスを初期化します。
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="outputOption"></param>
        /// <param name="sections"></param>
        public Record(DateTime dateTime, OutputOption outputOption, ICollection<Section> sections)
        {
            this.dateTime = dateTime;
            this.outputOption = outputOption;

            this.sections = new SectionCollection();
            foreach (var sec in sections)
                this.sections.Add(sec);
        }

        /// <summary>
        /// 日時と出力オプションを指定して、新しいRecordクラスのインスタンスを初期化します。
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="outputOption"></param>
        public Record(DateTime dateTime, OutputOption outputOption)
            : this(dateTime, outputOption, new Section[0])
        {
            // 実装なし
        }
        

        // 非公開メソッド

        private void _checkReadOnly(string target)
        {
            if (this.isReadOnly)
                throw new InvalidOperationException("対象のRecordは現在ロックされいるため、" + target + "を変更できません。");
        }

        private DateTime _getDateTime()
        {
            return this.dateTime;
        }

        private void _setDateTime(DateTime value)
        {
            this._checkReadOnly("DateTime");
            this.dateTime = value;
        }
        
        private string _getTitle()
        {
            string result = null;

            if (this.outputOption.TitleFormat != null)
            {
                result = this.outputOption.TitleFormat;
                
                // 置換処理→未実装
            }

            return result;
        }

        private SectionCollection _getSections()
        {
            if (this.isReadOnly)
                return this.sections.Clone();
            else
                return this.sections;
        }
    }
}
