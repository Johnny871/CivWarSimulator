# 文明/経済/戦争シミュレーター
## 概要
このプロジェクトは、ワールドに生成された町々が自動で発展し、戦争する様子を観察するシミュレーションです。

* * *

### 文明の内容

* * *

- **町の中心(TownHall)**
町につき1つしか存在しない中核の建物です。
ワールドの生成時にランダムな位置に生成されます。
この建物が破壊されることでその町の敗北が確定します。
下記のユニットの生成、町全体の倉庫としての役割を持っています。
※~~この建物に入ったユニットは体力が少しずつ回復していきます~~
※~~またユニットの生成等の資源を消費する行動を、倉庫内の資源量や町の状況を照会して決定するAIが組み込まれています。~~
※未実装

- **倉庫(Warehouse)**
生産ユニットが資源を納品する建物です。
町の中心はこの倉庫の要素も併せ持ちます。
各倉庫に資源が格納されるのではなく、倉庫に納品された資源は町の中心が持つマスター倉庫へまとめられます。

- **生産ユニット(ProduceUnit)**
周囲の資源を採取する作業員です。
町の中心の生成時にN体生成されます。
指定された種類の資源、または無指定場合は対象の資源の中から一番近い資源を採取して最寄りの倉庫に納品します。
※~~他の町から侵攻してきた戦闘ユニットと会敵した場合町の中心に逃げ込み、攻撃が止むまで籠城します~~
※未実装

- **戦闘ユニット(SoldierUnit)**
※~~町の防衛、他の町への侵攻を担当する兵士です。
町の中心から侵攻の指示が出るまで、基本的には生産ユニットの行動範囲をカバーするように巡回を行い、戦闘が起こった場所に集まります。
このユニットが他の全ての町の中心を破壊することが勝利条件となります。~~
~~ユニットの種類~~
	- ~~散兵~~
	- ~~弓兵~~
	- ~~重装兵~~
	- ~~騎兵~~
	
※未実装

* * *

### 環境

* * *

- **資源オブジェクト(Resource)**
	ワールドの生成時に、ランダムな位置にランダムな種類の資源オブジェクトが生成されます。
	資源オブジェクト内にある資源量が尽きるとオブジェクトごと消滅します。
	
	現在は三種類用意されています
	- 木(Wood)
	- 石(Stone)
	- 小麦(Wheat)
	
	各資源はユニットの生産、※~~建物の建設、研究など~~に使用されます。
	※未実装

- **バイオーム(Biome)**
	※~~ワールドの生成時にランダムな位置にランダムな範囲でバイオームが設定されます。
	バイオーム範囲内では特定の資源の出現率が増えたり、逆に減ったり、ユニットや建物に対してバフ/デバフ効果をかけたりと、様々な効果を与えます。~~
	
	~~バイオーム種類~~
	- ~~森
	木が多く生成されます~~
	- ~~山
	石が多く生成されます
	全ユニットの移動速度が低下します~~
	- ~~湿原
	全ユニットの移動速度が低下します~~
	- ~~平原
	小麦が多く生成されます
	全ユニットの移動速度が向上します~~

※未実装

* * *
