﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Mvc;
using System.Web.Routing;
using BootstrapForms.Utilities;

namespace BootstrapForms.HtmlHelpers
{
    /// <summary>
    /// Represents bootstrap v3 support for glyphicon fonts
    /// </summary>
    public static class GlyphiconExtensions
    {
        /// <summary>
        /// Returns a span element with glyphicon css
        /// </summary>
        public static MvcHtmlString BsGlyphicon<TModel>(this HtmlHelper<TModel> helper, Glyphicons icon, object htmlAttributes)
        {
            return BsGlyphicon(helper, icon, new RouteValueDictionary(htmlAttributes));
        }

        /// <summary>
        /// Returns a span element with glyphicon css
        /// </summary>
        public static MvcHtmlString BsGlyphicon<TModel>(this HtmlHelper<TModel> helper, Glyphicons icon)
        {
            return BsGlyphicon(helper, icon, (object)null);
        }

        /// <summary>
        /// Returns a span element with glyphicon css
        /// </summary>
        public static MvcHtmlString BsGlyphicon<TModel>(this HtmlHelper<TModel> helper, Glyphicons icon, IDictionary<string, object> htmlAttributes)
        {
            var spanTag = new TagBuilder("span");
            spanTag.MergeAttributes(htmlAttributes);
            spanTag.AddCssClass(icon.GetDescription());
            spanTag.AddCssClass("glyphicon");
            return MvcHtmlString.Create(spanTag.ToString(TagRenderMode.Normal));
        }

        /// <summary>
        /// Returns a span element with glyphicon css and input-group-addon, to be used inside a input-group div
        /// </summary>
        public static MvcHtmlString BsGlyphiconAddon<TModel>(this HtmlHelper<TModel> helper, Glyphicons icon, object htmlAttributes)
        {
            return BsGlyphiconAddon(helper, icon, new RouteValueDictionary(htmlAttributes));
        }

        /// <summary>
        /// Returns a span element with glyphicon css and input-group-addon, to be used inside a input-group div
        /// </summary>
        public static MvcHtmlString BsGlyphiconAddon<TModel>(this HtmlHelper<TModel> helper, Glyphicons icon)
        {
            return BsGlyphiconAddon(helper, icon, (object)null);
        }

        /// <summary>
        /// Returns a span element with glyphicon css and input-group-addon, to be used inside a input-group div
        /// </summary>
        public static MvcHtmlString BsGlyphiconAddon<TModel>(this HtmlHelper<TModel> helper, Glyphicons icon, IDictionary<string, object> htmlAttributes)
        {
            htmlAttributes.MergeAttribute("class", "input-group-addon");
            return BsGlyphicon(helper, icon, htmlAttributes);
        }
    }

    /// <summary>
    /// Glyphicon font symbols
    /// </summary>
    public enum Glyphicons
    {
        //when you want to specify a symbol that is not listed in this enum
        Custom,
        [Description("glyphicon-glass")]
        Glass,
        [Description("glyphicon-music")]
        Music,
        [Description("glyphicon-search")]
        Search,
        [Description("glyphicon-envelope")]
        Envelope,
        [Description("glyphicon-heart")]
        Heart,
        [Description("glyphicon-star")]
        Star,
        [Description("glyphicon-star-empty")]
        StartEmpty,
        [Description("glyphicon-user")]
        User,
        [Description("glyphicon-film")]
        Film,
        [Description("glyphicon-th-large")]
        ThLarge,
        [Description("glyphicon-th")]
        Th,
        [Description("glyphicon-th-list")]
        ThList,
        [Description("glyphicon-ok")]
        Ok,
        [Description("glyphicon-remove")]
        Remove,
        [Description("glyphicon-zoom-in")]
        ZoomIn,
        [Description("glyphicon-zoom-out")]
        ZoomOut,
        [Description("glyphicon-off")]
        Off,
        [Description("glyphicon-signal")]
        Signal,
        [Description("glyphicon-cog")]
        Cog,
        [Description("glyphicon-trash")]
        Trash,
        [Description("glyphicon-home")]
        Home,
        [Description("glyphicon-file")]
        File,
        [Description("glyphicon-time")]
        Time,
        [Description("glyphicon-road")]
        Road,
        [Description("glyphicon-download-alt")]
        DownloadAlt,
        [Description("glyphicon-download")]
        Download,
        [Description("glyphicon-upload")]
        Upload,
        [Description("glyphicon-inbox")]
        Inbox,
        [Description("glyphicon-play-circle")]
        PlayCircle,
        [Description("glyphicon-repeat")]
        Repeat,
        [Description("glyphicon-refresh")]
        Refresh,
        [Description("glyphicon-list-alt")]
        ListAlt,
        [Description("glyphicon-lock")]
        GLock,
        [Description("glyphicon-flag")]
        Flag,
        [Description("glyphicon-headphones")]
        Headphones,
        [Description("glyphicon-volume-off")]
        VolumeOff,
        [Description("glyphicon-volume-down")]
        VolumeDown,
        [Description("glyphicon-volume-up")]
        VolumeUp,
        [Description("glyphicon-qrcode")]
        Qrcode,
        [Description("glyphicon-barcode")]
        Barcode,
        [Description("glyphicon-tag")]
        Tag,
        [Description("glyphicon-tags")]
        Tags,
        [Description("glyphicon-book")]
        Book,
        [Description("glyphicon-bookmark")]
        Bookmark,
        [Description("glyphicon-print")]
        Print,
        [Description("glyphicon-camera")]
        Camera,
        [Description("glyphicon-font")]
        Font,
        [Description("glyphicon-bold")]
        Bold,
        [Description("glyphicon-italic")]
        Italic,
        [Description("glyphicon-text-height")]
        TextHeight,
        [Description("glyphicon-text-width")]
        TextWidth,
        [Description("glyphicon-align-left")]
        AlignLeft,
        [Description("glyphicon-align-center")]
        AlignCenter,
        [Description("glyphicon-align-right")]
        AlignRight,
        [Description("glyphicon-align-justify")]
        AlignJustify,
        [Description("glyphicon-list")]
        List,
        [Description("glyphicon-indent-left")]
        IndentLeft,
        [Description("glyphicon-indent-right")]
        IndentRight,
        [Description("glyphicon-facetime-video")]
        FacetimeVideo,
        [Description("glyphicon-picture")]
        Picture,
        [Description("glyphicon-pencil")]
        Pencil,
        [Description("glyphicon-map-marker")]
        MapMarker,
        [Description("glyphicon-adjust")]
        Adjust,
        [Description("glyphicon-tint")]
        Tint,
        [Description("glyphicon-edit")]
        Edit,
        [Description("glyphicon-share")]
        Share,
        [Description("glyphicon-check")]
        Check,
        [Description("glyphicon-move")]
        Move,
        [Description("glyphicon-step-backward")]
        StepBackward,
        [Description("glyphicon-fast-backward")]
        FastBackward,
        [Description("glyphicon-backward")]
        Backward,
        [Description("glyphicon-play")]
        Play,
        [Description("glyphicon-pause")]
        Pause,
        [Description("glyphicon-stop")]
        Stop,
        [Description("glyphicon-forward")]
        Forward,
        [Description("glyphicon-fast-forward")]
        FastForward,
        [Description("glyphicon-step-forward")]
        StepForward,
        [Description("glyphicon-eject")]
        Eject,
        [Description("glyphicon-chevron-left")]
        ChevronLeft,
        [Description("glyphicon-chevron-right")]
        ChevronRight,
        [Description("glyphicon-plus-sign")]
        PlusSign,
        [Description("glyphicon-minus-sign")]
        MinusSign,
        [Description("glyphicon-remove-sign")]
        RemoveSign,
        [Description("glyphicon-ok-sign")]
        OkSign,
        [Description("glyphicon-question-sign")]
        QuestionSign,
        [Description("glyphicon-info-sign")]
        InfoSign,
        [Description("glyphicon-screenshot")]
        Screenshot,
        [Description("glyphicon-remove-circle")]
        RemoveCircle,
        [Description("glyphicon-ok-circle")]
        OkCircle,
        [Description("glyphicon-ban-circle")]
        BanCircle,
        [Description("glyphicon-arrow-left")]
        ArrowLeft,
        [Description("glyphicon-arrow-right")]
        ArrowRight,
        [Description("glyphicon-arrow-up")]
        ArrowUp,
        [Description("glyphicon-arrow-down")]
        ArrowDown,
        [Description("glyphicon-share-alt")]
        ShareAlt,
        [Description("glyphicon-resize-full")]
        ResizeFull,
        [Description("glyphicon-resize-small")]
        ResizeSmall,
        [Description("glyphicon-plus")]
        Plus,
        [Description("glyphicon-minus")]
        Minus,
        [Description("glyphicon-asterisk")]
        Asterisk,
        [Description("glyphicon-exclamation-sign")]
        ExclamationSign,
        [Description("glyphicon-gift")]
        Gift,
        [Description("glyphicon-leaf")]
        Leaf,
        [Description("glyphicon-fire")]
        Fire,
        [Description("glyphicon-eye-open")]
        EyeOpen,
        [Description("glyphicon-eye-close")]
        EyeClose,
        [Description("glyphicon-warning-sign")]
        WarningSign,
        [Description("glyphicon-plane")]
        Plane,
        [Description("glyphicon-calendar")]
        Calendar,
        [Description("glyphicon-random")]
        Random,
        [Description("glyphicon-comment")]
        Comment,
        [Description("glyphicon-magnet")]
        Magnet,
        [Description("glyphicon-chevron-up")]
        ChevronUp,
        [Description("glyphicon-chevron-down")]
        ChevronDown,
        [Description("glyphicon-retweet")]
        Retweet,
        [Description("glyphicon-shopping-cart")]
        ShoppingCart,
        [Description("glyphicon-folder-close")]
        FolderClose,
        [Description("glyphicon-folder-open")]
        FolderOpen,
        [Description("glyphicon-resize-vertical")]
        ResizeVertical,
        [Description("glyphicon-resize-horizontal")]
        ResizeHorizontal,
        [Description("glyphicon-hdd")]
        Hdd,
        [Description("glyphicon-bullhorn")]
        Bullhorn,
        [Description("glyphicon-bell")]
        Bell,
        [Description("glyphicon-certificate")]
        Certificate,
        [Description("glyphicon-thumbs-up")]
        ThumbsUp,
        [Description("glyphicon-thumbs-down")]
        ThumbsDown,
        [Description("glyphicon-hand-right")]
        HandRight,
        [Description("glyphicon-hand-left")]
        HandLeft,
        [Description("glyphicon-hand-up")]
        HandUp,
        [Description("glyphicon-hand-down")]
        HandDown,
        [Description("glyphicon-circle-arrow-right")]
        CircleArrowRight,
        [Description("glyphicon-circle-arrow-left")]
        CircleArrowLeft,
        [Description("glyphicon-circle-arrow-up")]
        CircleArrowUp,
        [Description("glyphicon-circle-arrow-down")]
        CircleArrowDown,
        [Description("glyphicon-globe")]
        Globe,
        [Description("glyphicon-wrench")]
        Wrench,
        [Description("glyphicon-tasks")]
        Tasks,
        [Description("glyphicon-filter")]
        Filter,
        [Description("glyphicon-briefcase")]
        Briefcase,
        [Description("glyphicon-fullscreen")]
        Fullscreen,
        [Description("glyphicon-collapse-dashboard")]
        Dashboard,
        [Description("glyphicon-collapse-paperclip")]
        Paperclip,
        [Description("glyphicon-collapse-heart-empty")]
        HeartEmpty,
        [Description("glyphicon-collapse-link")]
        Link,
        [Description("glyphicon-collapse-phone")]
        Phone,
        [Description("glyphicon-collapse-pushpin")]
        Pushpin,
        [Description("glyphicon-euro")]
        Euro,
        [Description("glyphicon-usd")]
        Usd,
        [Description("glyphicon-gbp")]
        Gbp,
        [Description("glyphicon-sort")]
        Sort,
        [Description("glyphicon-sort-by-alphabet")]
        SortByAlphabet,
        [Description("glyphicon-ort-by-alphabet-alt")]
        SortByAlphabetAlt,
        [Description("glyphicon-sort-by-attributes")]
        SortByAttributes,
        [Description("glyphicon-sort-by-attributes-alt")]
        SortByAttributesAlt,
        [Description("glyphicon-unchecked")]
        Unchecked,
        [Description("glyphicon-expand")]
        Expand,
        [Description("glyphicon-collapse")]
        Collapse,
        [Description("glyphicon-collapse-top")]
        CollapseTop
    }
}