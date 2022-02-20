﻿namespace PopStudio.ConsoleProject.Constant
{
    internal class ZHCN : ILanguage
    {
        static readonly string[] all = {
            "{0} {1}",
            "作者：{0}",
            "你好！这是一个用于转换宝开游戏中使用的格式的项目。",
            "输入1以运行解包模式",
            "输入2以运行打包模式",
            "输入3以运行图像解码模式",
            "输入4以运行图像编码模式",
            "如果你想解包.dz，请输入1.",
            "如果你想解包.rsb，请输入2.",
            "如果你想解包.pak，请输入3.",
            "请选择dz文件",
            "请选择rsb文件",
            "请选择pak文件",
            "如果你想打包.dz，请输入1.",
            "如果你想打包.rsb，请输入2.",
            "如果你想打包.pak，请输入3.",
            "请选择dz源文件夹",
            "请选择rsb源文件夹",
            "请选择pak源文件夹",
            "如果你想解码.ptx（rsb中的），请输入1.",
            "如果你想解码.cdat，请输入2.",
            "如果你想解码.tex（iOS版），请输入3.",
            "如果你想解码.txz，请输入4.",
            "如果你想解码.tex（安卓TV版），请输入5.",
            "如果你想解码.ptx（植物大战僵尸Xbox360中的），请输入6.",
            "如果你想解码.ptx（植物大战僵尸PS3中的），请输入7.",
            "请选择ptx文件",
            "请选择cdat文件",
            "请选择tex文件",
            "请选择txz文件",
            "如果你想编码.ptx（rsb中的），请输入1.",
            "如果你想编码.cdat，请输入2.",
            "如果你想编码.tex（iOS版），请输入3.",
            "如果你想编码.txz，请输入4.",
            "如果你想编码.tex（安卓TV版），请输入5.",
            "如果你想编码.ptx（植物大战僵尸Xbox360中的），请输入6.",
            "如果你想编码.ptx（植物大战僵尸PS3中的），请输入7.",
            "请选择png文件",
            "请选择模式",
            "输入1使用ARGB8888纹理（格式0）",
            "输入2使用ABGR8888纹理（格式0）",
            "输入3使用RGBA4444纹理（格式1）",
            "输入4使用RGB565纹理（格式2）",
            "输入5使用RGBA5551纹理（格式3）",
            "输入6使用RGBA4444_Block纹理（格式21）",
            "输入7使用RGB565_Block纹理（格式22）",
            "输入8使用RGBA5551_Block纹理（格式23）",
            "输入9使用XRGB8888_A8纹理（格式149）",
            "输入10使用ARGB8888大端序纹理（格式0）",
            "输入11使用ARGB8888大端序补码纹理（格式0）",
            "输入12使用DXT1_RGB纹理（格式35）",
            "输入13使用DXT3_RGBA纹理（格式36）",
            "输入14使用DXT5_RGBA纹理（格式37）",
            "输入15使用DXT5纹理（格式5）",
            "输入16使用DXT5大端序纹理（格式5）",
            "输入17使用ETC1_RGB纹理（格式32）",
            "输入18使用ETC1_RGB_A8纹理（格式147）",
            "输入19使用ETC1_RGB_A_Palette纹理（格式147）",
            "输入20使用ETC1_RGB_A_Palette纹理（格式150）",
            "输入21使用PVRTC_4BPP_RGBA纹理（格式30）",
            "输入22使用PVRTC_4BPP_RGB_A8纹理（格式148）",
            "输入23使用PVRTC_2BPP_RGBA纹理（格式31）",
            "输入1使用ABGR8888纹理（格式1）",
            "输入2使用RGBA4444纹理（格式2）",
            "输入3使用RGBA5551纹理（格式3）",
            "输入4使用RGB565纹理（格式4）",
            "输入1使用LUT8纹理（格式1）（无效）",
            "输入2使用ARGB8888纹理（格式2）",
            "输入3使用ARGB4444纹理（格式3）",
            "输入4使用ARGB1555纹理（格式4）",
            "输入5使用RGB565纹理（格式5）",
            "输入6使用ABGR8888纹理（格式6）",
            "输入7使用RGBA4444纹理（格式7）",
            "输入8使用RGBA5551纹理（格式8）",
            "输入9使用XRGB8888纹理（格式9）",
            "输入10使用LA88纹理（格式10）",
            "无效模式！",
            "输入5以运行RTON解码模式",
            "输入6以运行RTON编码模式",
            "如果你想解码普通.RTON，请输入1.",
            "如果你想解码加密.RTON，请输入2.（需要自行输入密钥）",
            "如果你想编码普通.RTON，请输入1.",
            "如果你想编码加密.RTON，请输入2.（需要自行输入密钥）",
            "请选择RTON文件",
            "请选择json文件",
            "请输入密钥",
            "输入7以运行reanim解码模式（解码为json）",
            "输入8以运行reanim编码模式（从json编码）",
            "如果你想解码PC版（Windows和MacOS），请输入1.",
            "如果你想解码Phone32版（安卓和iOS），请输入2.",
            "如果你想解码Phone64版（安卓和iOS），请输入3.",
            "如果你想解码WP版（WindowsPhone），请输入4.",
            "如果你想解码GameConsole版（PS3，PSV和Xbox360），请输入5.",
            "如果你想解码TV版（AndroidTV），请输入6.",
            "如果你想编码PC版（Windows和MacOS），请输入1.",
            "如果你想编码Phone32版（安卓和iOS），请输入2.",
            "如果你想编码Phone64版（安卓和iOS），请输入3.",
            "如果你想编码WP版（WindowsPhone），请输入4.",
            "如果你想编码GameConsole版（PS3，PSV和Xbox360），请输入5.",
            "如果你想编码TV版（AndroidTV），请输入6.",
            "请选择reanim.compiled文件",
            "请选择xnb文件",
            "请选择reanim文件",
            "输入9以运行trail解码模式（解码为json）",
            "输入10以运行trail编码模式（从json编码）",
            "请选择trail.compiled文件",
            "请选择xnb文件",
            "请选择trail文件",
            "如果你想解码.ptx（植物大战僵尸PSV中的），请输入8.",
            "如果你想编码.ptx（植物大战僵尸PSV中的），请输入8.",
        };

        public string[] All => all;
    }
}
