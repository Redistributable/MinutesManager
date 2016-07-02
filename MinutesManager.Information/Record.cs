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
        private string title;
        private SectionCollection sections;
        private bool isReadOnly;

        
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
        /// この議事録のタイトルを取得・設定します。IsReadOnlyがtrueの場合、設定操作が無効になります。
        /// </summary>
        public string Title
        {
            get { return this._getTitle(); }
            set { this._setTitle(value); }
        }

        /// <summary>
        /// この議事録に含まれるセクションのコレクションを取得します。IsReadOnlyがtrueの場合、複製されたコレクションのインスタンスを取得します。
        /// </summary>
        public SectionCollection Sections
        {
            get { return this._getSections(); }
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
            return this.title;
        }

        private void _setTitle(string value)
        {
            this._checkReadOnly("Title");
            this.title = value;
        }

        public SectionCollection _getSections()
        {
            if (this.isReadOnly)
                return this.sections.Clone();
            else
                return this.sections;
        }
    }
}
