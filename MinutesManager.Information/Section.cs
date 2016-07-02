using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Redefinable;
using Redefinable.Collections;


namespace Redefinable.Applications.MinutesManager.Information
{
    /// <summary>
    /// Contentの集合であるセクションのコレクション機能を提供します。
    /// </summary>
    public class SectionCollection : NativeEventDefinedList<Section>
    {
        // 実装なし
    }

    /// <summary>
    /// Contentの集合であるセクションについての情報を格納します。
    /// </summary>
    public class Section
    {
        // 非公開フィールド
        private string title;
        private ContentCollection contents;


        // 公開フィールド・プロパティ
        
        /// <summary>
        /// このセクションの名前を取得・設定します。
        /// </summary>
        public string Title
        {
            get { return this.title; }
            set { this.title = value; }
        }

        /// <summary>
        /// このセクションに含まれる議題・報告内容についてのコレクションを取得します。
        /// </summary>
        public ContentCollection Contents
        {
            get { return this.contents; }
        }


        // コンストラクタ

        /// <summary>
        /// セクションの名前を指定して、新しいSectionクラスのインスタンスを初期化します。
        /// </summary>
        /// <param name="title"></param>
        public Section(string title)
        {
            this.title = title;
        }

        /// <summary>
        /// 新しいSectionクラスのインスタンスを初期化します。
        /// </summary>
        public Section()
            : this("Untitled section")
        {
            this.contents = new ContentCollection();
        }
        
        /// <summary>
        /// セクション名と追加するContentのコレクションを指定して、新しいSectionクラスのインスタンスを初期化します。
        /// </summary>
        /// <param name="title"></param>
        /// <param name="contents"></param>
        public Section(string title, ICollection<Content> contents)
            : this(title)
        {
            this._addContents(contents);
        }


        // 非公開メソッド

        /// <summary>
        /// 現在のContentコレクションへ新しいContentを追加します。
        /// </summary>
        private void _addContents(ICollection<Content> contents)
        {
            foreach (Content c in contents)
                this.contents.Add(c);
        }

        
        // 公開メソッド

        /// <summary>
        /// 指定したContentを現在のContentコレクションへ追加します。
        /// </summary>
        /// <param name="content"></param>
        public void AddContent(Content content)
        {
            this._addContents(new Content[] { content });
        }

        /// <summary>
        /// 指定した複数のContentを現在のContentコレクションへ追加します。
        /// </summary>
        /// <param name="contents"></param>
        public void AddContents(ICollection<Content> contents)
        {
            this._addContents(contents);
        }
    }
}
