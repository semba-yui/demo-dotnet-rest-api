# Contributing to the project

## Branching and Release Workflow

[Git Flow](https://www.atlassian.com/ja/git/tutorials/comparing-workflows/gitflow-workflow) に従う。

## Style Guide

### Commit Messages

| プレフィックス   | 説明                                               |
|:----------|:-------------------------------------------------|
| feat:     | 新機能                                              |
| fix:      | バグの修正                                            |
| docs:     | ドキュメントのみの変更                                      |
| style:    | コードの動作に影響しない、見た目だけの変更（スペース、フォーマット、欠落の修正、セミコロンなど） |
| refactor: | バグの修正や機能の追加ではないコードの変更                            |
| perf:     | パフォーマンスを向上させるコードの変更                              |
| test:     | 不足しているテストの追加や既存のテストの修正                           |
| chore:    | ビルドプロセスやドキュメント生成などの補助ツールやライブラリの変更                |

https://www.conventionalcommits.org/ja/v1.0.0/

### Code Style

MS 標準に従う。
コードフォーマッタは `.editorconfig` に指定する。

- [C# 識別子の名前付け規則と表記規則](https://learn.microsoft.com/ja-jp/dotnet/csharp/fundamentals/coding-style/identifier-names)
- [一般的な C# のコード規則](https://learn.microsoft.com/ja-jp/dotnet/csharp/fundamentals/coding-style/coding-conventions)
