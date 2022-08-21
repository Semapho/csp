# 贡献指南

欢迎对这个项目进行 PR，但在贡献之前，请记住我在下面的想法。如果可能，请进行所有的单元测试。如果您不确定是否参与，请询问（在 [QQ群: 444093737](https://jq.qq.com/?_wv=1027&k=CWt7TZln) 中打个招呼）。

## 这个仓库的目的：

此软件的目的是兼容国产的 MCU 与 SOC 系列，目前国产公司的芯片开发环境一言难尽，甚至连数据手册都不愿意公开。在一颗 STM32 卖的比我电脑 CPU 还贵的时代，这是我不愿意看到的。尽管，大家可能会想：“国产 MCU，大都是都是为了抢占 STM32 的市场，他们的代码甚至可以直接兼容 HAL 库，为什么我不直接用cube呢？”。对此，我想说，此软件的目的绝不只有简单芯片基础配置功能：支持国产操作系统RTT，能够直接进行RTT的移植，一键创建线程等功能。加入外设芯片软件包，一些通用外设芯片，例如 Flash、IMU、EEPROM 等，可以一键移植。对于一些较为封闭的厂商芯片，也可以将代码打包成库，供大家进行选型以及参考。总的来说，我个人认为这并不是无用功。

## 代码标准：

我使用标准 Visual Studio 设置进行代码编写，使用 Resharper，并采用（大部分）ReSharper 的建议。我希望代码看起来非常相似。

API 为王。如果向该仓库的公共接口（控件、助手等）添加任何内容，请注意命名和使用。如果我接受您的 PR 但稍微重命名，请不要生气。

## 提交 PR：

可能越小越好（在您的更改性质的合理范围内）；至少将单个功能保留到单个分支/ PR。