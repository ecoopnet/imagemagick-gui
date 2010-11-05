immex - ImageMagick GUI Executor
Author: M.Inomata
URL: http://www.ecoop.net/
mail: M_Inomata@hotmail.co.jp


◎このソフトについて
ImageMagick のコマンドラインインターフェイスである convert コマンドの
簡易実行環境です。ImageMagick の学習用や簡易編集環境としてご利用下さい。

コマンドを入力して実行ボタン(またはF5キー)を押すと、
実行結果(※)が画像表示パネルに瞬時に反映されます。

※初期設定では標準出力を取得し表示します。
　設定を変更する事で標準出力の代わりに任意の画像ファイルを監視し、
　表示する事も可能です。


実行コマンドウィンドウから ImageMagick の convert コマンドを入力し、実行ボタンを押すと

◎ImageMagick の使い方
ImageMagick公式サイトをご参照ください。

■基本的な使い方
http://www.imagemagick.org/script/command-line-processing.php

■コマンドラインオプション一覧
http://www.imagemagick.org/script/command-line-options.php

■利用例、実用的なサンプル
http://www.imagemagick.org/Usage/


◎必要環境
.NET Framework 3.5 

◎その他
convert コマンドでは最後のファイル名が出力ファイルになります。
ファイル出力せず、標準出力を行うには convert コマンド引数の最後に、
ファイル名の代わりにハイフン(-)単体を指定するか、jpg:- のように画
像形式を指定してください。ハイフンのみの場合、入力画像形式と同じ形
式で出力します。

例:
GIF画像 input.gif を読み込んで色反転し、JPEG 画像 out.jpg として出力。
> convert input.gif -negate out.jpg

PNG画像 input.png を読み込み、回転、リサイズ後標準出力に PNG 形式で出力。
> convert input.png -flip -resize 300x300 -

JPG 画像と PNG 画像を読み込み、連結して標準出力に JPEG 形式で出力。
> convert input1.jpg input2.png -append jpg:-
