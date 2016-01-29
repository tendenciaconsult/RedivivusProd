using Simir.Application.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;


namespace Simir.WebInterfaceComAuth.Helpers
{
    public static class HtmlCustom
    {

        public static TAttribute GetModelAttribute<TAttribute>
(this ViewDataDictionary viewData, bool inherit = false) where TAttribute : Attribute
        {
            if (viewData == null) throw new ArgumentException("ViewData");
            var containerType = viewData.ModelMetadata.ContainerType;
            return
                ((TAttribute[])
                 containerType.GetProperty(viewData.ModelMetadata.PropertyName).
                 GetCustomAttributes(typeof(TAttribute),
                 inherit)).
                    FirstOrDefault();

        }
        public static IHtmlString RenderScripts(this HtmlHelper htmlHelper)
        {
            var scripts = htmlHelper.ViewContext.HttpContext.Items["Scripts"] as IList<string>;
            if (scripts != null)
            {
                var builder = new StringBuilder();
                foreach (var script in scripts)
                {
                    builder.AppendLine(script);
                }
                return new MvcHtmlString(builder.ToString());
            }
            return null;
        }





        public static MvcHtmlString EditBootstrapFor<TModel, TValue>(this HtmlHelper<TModel> self, Expression<Func<TModel, TValue>> expression, int tudoTamanho = 0, int inputTamanho = 12)
        {
            var member = expression.Body as MemberExpression;
            var stringLength = member.Member
                .GetCustomAttributes(typeof(StringLengthAttribute), false)
                .FirstOrDefault() as StringLengthAttribute;

            var mask = member.Member
               .GetCustomAttributes(typeof(InputMaskAttribute), false)
               .FirstOrDefault() as InputMaskAttribute;

            var ajudaAtr = member.Member
               .GetCustomAttributes(typeof(AjudaAttribute), false)
               .FirstOrDefault() as AjudaAttribute;

            bool requerido = (member.Member
               .GetCustomAttributes(typeof(RequiredAttribute), false)
               .FirstOrDefault() as RequiredAttribute) != null;
            
            var attributes = new Dictionary<string, object>();
            
            int maxLength = 200;
            if (stringLength != null)
                maxLength = stringLength.MaximumLength;
            else if (mask != null)
                maxLength = mask.Mask.Length;

            attributes.Add("maxlength", maxLength);

            int largura = tudoTamanho;
            if (tudoTamanho == 0)
            {
                largura = Convert.ToInt32(Math.Sqrt(maxLength * 1.8));
                if(mask != null && mask.TemFinal){
                    largura += mask.Final.Length / 2;
                }
            }

            if (largura > 12) largura = 12;

            attributes.Add(@"class", "form-control");
            var metadata = ModelMetadata.FromLambdaExpression(expression, self.ViewData);
            var description = metadata.Description;
            if (description != null)
                attributes.Add("placeholder", description);

            if (mask != null)
            {
                attributes.Add(@"data-mask", mask.Mask);
                if (mask.IsReverso)
                {
                    attributes["class"]= "form-control text-right";
                    
                    attributes.Add(@"data-mask-reverse", "True");
                    if (mask.Mask.Count(x => x != '0') == 0)
                    {
                        attributes.Add(@"type", "number");
                    }
                }
            }


            var partial = self.LabelFor(expression).ToHtmlString();
            if(ajudaAtr != null)
                partial += string.Format(@" <abbr class='tooltip2' title='{0}'><i class='fa fa-question-circle'></i></abbr>", ajudaAtr.Ajuda);
            if (requerido) partial += " *";
            //partial += 
            var input = self.TextBoxFor(expression, attributes).ToHtmlString();
            
            if (inputTamanho > 12) inputTamanho = 12;
            partial += string.Format(@"<div class='input-group col-xs-{0}'>", inputTamanho);
            partial += input;
            if(mask != null && mask.TemFinal){
                
                partial +="<span class='input-group-addon'>"+ mask.Final +"</span></div>";
                
            }else{
                partial += "</div>";
            }
            partial += self.ValidationMessageFor(expression, "", new { @class = "text-danger" });
             //"$(document).ready(function () {{$('#{0}').mask('{1}');}});";

            //partial += metadata.;

            if (mask != null && mask.Mask == "99/99/9999") 
                return MvcHtmlString.Create(string.Format(@"<div class='form-group umadata col-xs-{0}'>{1} </div>",largura, partial));
            if (mask != null && mask.Mask == "00:00")
                return MvcHtmlString.Create(string.Format(@"<div class='form-group umahora col-xs-{0}'>{1} </div>", largura, partial));
            if (mask != null && mask.Mask == "99/9999")
                return MvcHtmlString.Create(string.Format(@"<div class='form-group ummes col-xs-{0}'>{1} </div>", largura, partial));
            else
                return MvcHtmlString.Create(string.Format(@"<div class='form-group col-xs-{0}'>{1} </div>", largura, partial));
        }

        public static MvcHtmlString CheckBoxBootstrapFor<TModel>(this HtmlHelper<TModel> self, Expression<Func<TModel, bool>> expression)
        {
            var member = expression.Body as MemberExpression;

            var ajudaAtr = member.Member
               .GetCustomAttributes(typeof(AjudaAttribute), false)
               .FirstOrDefault() as AjudaAttribute;


            var partial = self.CheckBoxFor(expression).ToHtmlString();
            partial += self.DisplayNameFor(expression).ToHtmlString();

            if (ajudaAtr != null)
                partial += string.Format(@" <abbr class='tooltip2' title='{0}'><i class='fa fa-question-circle'></i></abbr>", ajudaAtr.Ajuda);


            return MvcHtmlString.Create(string.Format(@"<div class='checkbox'><label>{0}</label> </div>", partial));
            
        }

        public static MvcHtmlString DDLBootstrapFor<TModel>(this HtmlHelper<TModel> self, Expression<Func<TModel, String>> expression, String descricao, String url)
        {
            

            var member = expression.Body as MemberExpression;
            var stringLength = member.Member
                .GetCustomAttributes(typeof(StringLengthAttribute), false)
                .FirstOrDefault() as StringLengthAttribute;
            var ajudaAtr = member.Member
               .GetCustomAttributes(typeof(AjudaAttribute), false)
               .FirstOrDefault() as AjudaAttribute;

            int maxLength = 200;
            if (stringLength != null)
                maxLength = stringLength.MaximumLength;

            int largura = Convert.ToInt32(Math.Sqrt(maxLength * 1.8));
            if (largura > 12) largura = 12;

            var partial = self.LabelFor(expression).ToHtmlString();
            if (ajudaAtr != null)
                partial += string.Format(@" <abbr class='tooltip2' title='{0}'><i class='fa fa-question-circle'></i></abbr>", ajudaAtr.Ajuda);
            
            partial += string.Format(@"<select class='form-control simir-ddl ' simir-ddl-url='{0}' simir-ddl-pai='nulo' simir-ddl-filho='nulo' >", url);
            //partial += string.Format(@"<select class='form-control' onclick=""refreshDDL(this, '{0}'); return; "" onchange='changeDDL(this); return;'>", url);
            partial += string.Format(@"<option value='{0}'> {1} </option></select>", "-1", descricao);
            partial += self.HiddenFor(expression, new { @class = "hiddenFor" });
            partial += self.ValidationMessageFor(expression, "", new { @class = "text-danger" });
            return MvcHtmlString.Create(string.Format(@"<div class='form-group col-xs-{0}'>{1} </div>", largura, partial));
        }

        public static MvcHtmlString DDLBootstrapFor2<TModel>(this HtmlHelper<TModel> self, Expression<Func<TModel, String>> expression, String descricao, String url, Expression<Func<TModel, String>> pai, Expression<Func<TModel, String>> filho)
        {


            var member = expression.Body as MemberExpression;
            var stringLength = member.Member
                .GetCustomAttributes(typeof(StringLengthAttribute), false)
                .FirstOrDefault() as StringLengthAttribute;

            var ajudaAtr = member.Member
               .GetCustomAttributes(typeof(AjudaAttribute), false)
               .FirstOrDefault() as AjudaAttribute;
            int maxLength = 200;
            if (stringLength != null)
                maxLength = stringLength.MaximumLength;

            int largura = Convert.ToInt32(Math.Sqrt(maxLength * 1.8));
            if (largura > 12) largura = 12;

            string fieldName = ((MemberExpression)expression.Body).Member.Name;
            string fieldFilho = "nulo";
            if (filho != null)
                fieldFilho = ((MemberExpression)filho.Body).Member.Name;
            string fieldPai = "nulo";
            if (pai != null)
                fieldPai = ((MemberExpression)pai.Body).Member.Name;


            var partial = self.LabelFor(expression).ToHtmlString();
            if (ajudaAtr != null)
                partial += string.Format(@" <abbr class='tooltip2' title='{0}'><i class='fa fa-question-circle'></i></abbr>", ajudaAtr.Ajuda);
            //partial += string.Format(@" <abbr title='{0}'><i class='fa fa-question-circle'></i></abbr>", descricao);
            partial += string.Format(@"<select class='form-control  {0}' onclick=""refreshDDL(this, '{1}', '{2}'); return; "" onchange=""changeDDL(this, '{3}'); return;"">", fieldName, url,fieldPai, fieldFilho);
            partial += string.Format(@"<option value='{0}'> {1} </option>", "-1", descricao);
            partial += "<option> </option><option> </option><option> </option><option> </option><option> </option></select>";
            partial += self.HiddenFor(expression, new { @class = "hiddenFor" });
            partial += self.ValidationMessageFor(expression, "", new { @class = "text-danger" });
            return MvcHtmlString.Create(string.Format(@"<div class='form-group col-xs-{0}'>{1} </div>", largura, partial));
        }
        public static MvcHtmlString DDLBootstrapFor<TModel>(this HtmlHelper<TModel> self, Expression<Func<TModel, String>> expression, Expression<Func<TModel, String>> descricao, String url, Expression<Func<TModel, String>> pai, Expression<Func<TModel, String>> filho)
        {
            string pais = null;
            if (pai !=null)
            pais = ((MemberExpression)pai.Body).Member.Name;

            return DDLBootstrapFor(self, expression, descricao, url, pais, filho);
                
 
        }

        public static MvcHtmlString DDLBootstrapFor<TModel>(this HtmlHelper<TModel> self, Expression<Func<TModel, String>> expression, Expression<Func<TModel, String>> descricao, String url, String pais, Expression<Func<TModel, String>> filho)
        {

            var member = expression.Body as MemberExpression;
            var stringLength = member.Member
                .GetCustomAttributes(typeof(StringLengthAttribute), false)
                .FirstOrDefault() as StringLengthAttribute;

            var ajudaAtr = member.Member
               .GetCustomAttributes(typeof(AjudaAttribute), false)
               .FirstOrDefault() as AjudaAttribute;
            int maxLength = 200;
            if (stringLength != null)
                maxLength = stringLength.MaximumLength;

            int largura = Convert.ToInt32(Math.Sqrt(maxLength * 1.8));
            if (largura > 12) largura = 12;

            string fieldName = ((MemberExpression)expression.Body).Member.Name;
            string fieldFilho = "nulo";
            if (filho != null)
                fieldFilho = ((MemberExpression)filho.Body).Member.Name;
            string fieldPai = "nulo";
            if (!String.IsNullOrWhiteSpace(pais))
            {
                fieldPai = pais;                
            }

            var partial = self.LabelFor(expression).ToHtmlString();
            if (ajudaAtr != null)
                partial += string.Format(@" <abbr class='tooltip2' title='{0}'><i class='fa fa-question-circle'></i></abbr>", ajudaAtr.Ajuda);

            partial += string.Format(@"<select class='form-control simir-ddl {0}' simir-ddl-url='{1}' simir-ddl-pai='{2}'  simir-ddl-filho='{3}' >", fieldName, url, fieldPai, fieldFilho);
            var descriValue = ModelMetadata.FromLambdaExpression(
                   descricao, self.ViewData
            ).Model;
            if (descriValue != null)
                partial += string.Format(@"<option value='{0}'> {1} </option> </select>", "-1", descriValue.ToString());
            else
                partial += string.Format(@"<option value='{0}'> {1} </option> </select>", "-1", "");
            partial += self.HiddenFor(expression, new { @class = "hiddenFor" });
            partial += self.HiddenFor(descricao, new { @class = "hiddenFor" });
            partial += self.ValidationMessageFor(expression, "", new { @class = "text-danger" });
            return MvcHtmlString.Create(string.Format(@"<div class='form-group col-xs-{0}'>{1} </div>", largura, partial));
        }


        public static MvcHtmlString CheckBoxListBootstrapFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, IEnumerable<SelectListItem> items)
        {
            var listName = ExpressionHelper.GetExpressionText(expression);
            var metaData = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);

            items = GetCheckboxListWithDefaultValues(metaData.Model, items);
            return htmlHelper.CheckBoxList(listName, items);
        }

        public static MvcHtmlString CheckBoxList(this HtmlHelper htmlHelper, string listName, IEnumerable<SelectListItem> items, object htmlAttributes = null)
        {
            var container = new TagBuilder("div");
            foreach (var item in items)
            {
                var label = new TagBuilder("label");
                label.MergeAttribute("class", "checkbox"); // default class
                label.MergeAttributes(new RouteValueDictionary(htmlAttributes), true);

                var cb = new TagBuilder("input");
                cb.MergeAttribute("type", "checkbox");
                cb.MergeAttribute("name", listName);
                cb.MergeAttribute("value", item.Value ?? item.Text);
                if (item.Selected)
                    cb.MergeAttribute("checked", "checked");

                label.InnerHtml = cb.ToString(TagRenderMode.SelfClosing) + item.Text;

                container.InnerHtml += label.ToString();
            }

            return new MvcHtmlString(container.ToString());
        }

        private static IEnumerable<SelectListItem> GetCheckboxListWithDefaultValues(object defaultValues, IEnumerable<SelectListItem> selectList)
        {
            var defaultValuesList = defaultValues as IEnumerable;

            if (defaultValuesList == null)
                return selectList;

            IEnumerable<string> values = from object value in defaultValuesList
                                         select Convert.ToString(value, CultureInfo.CurrentCulture);

            var selectedValues = new HashSet<string>(values, StringComparer.OrdinalIgnoreCase);
            var newSelectList = new List<SelectListItem>();

            selectList.ToList().ForEach(item =>
            {
                item.Selected = (item.Value != null) ? selectedValues.Contains(item.Value) : selectedValues.Contains(item.Text);
                newSelectList.Add(item);
            });

            return newSelectList;
        }

        public static MvcHtmlString DescriptionFor<TModel, TValue>(this HtmlHelper<TModel> self, Expression<Func<TModel, TValue>> expression)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, self.ViewData);
            var description = metadata.Description;

            return MvcHtmlString.Create(string.Format(@"<span class='help-block'>{0}</span>", description));
        }



        /// <param name="linkText">Text for Link</param>
        /// <param name="containerElement">where this block will be inserted in the HTML using a jQuery append method</param>
        /// <param name="counterElement">name of the class inserting, used for counting the number of items on the form</param>
        /// <param name="collectionProperty">the prefix that needs to be added to the generated HTML elements</param>
        /// <param name="nestedType">The type of the class you're inserting</param>
        public static IHtmlString LinkToAddNestedForm<TModel>(this HtmlHelper<TModel> htmlHelper, string linkText,
            string containerElement, string counterElement, string collectionProperty, Type nestedType)
        {
            var ticks = DateTime.UtcNow.Ticks;
            var nestedObject = Activator.CreateInstance(nestedType);
            var partial = htmlHelper.EditorFor(x => nestedObject).ToHtmlString().JsEncode();

            partial = partial.Replace("id=\\\"nestedObject", "id=\\\"" + collectionProperty + "_" + ticks + "_");
            partial = partial.Replace("name=\\\"nestedObject", "name=\\\"" + collectionProperty + "[" + ticks + "]");

            var js = string.Format("javascript:addNestedForm('{0}','{1}','{2}','{3}');return false;", containerElement,
                counterElement, ticks, partial);

            TagBuilder tb = new TagBuilder("a");
            tb.Attributes.Add("href", "#");
            tb.Attributes.Add("onclick", js);
            tb.InnerHtml = linkText;

            var tag = tb.ToString(TagRenderMode.Normal);
            return MvcHtmlString.Create(tag);
        }


        public static IHtmlString LinkToRemoveNestedForm(this HtmlHelper htmlHelper, string linkText, string container, string deleteElement)
        {

            var js = string.Format("javascript:removeNestedForm(this,'{0}','{1}');return false;", container, deleteElement);

            TagBuilder tb = new TagBuilder("a");

            tb.Attributes.Add("href", "#");

            tb.Attributes.Add("onclick", js);


            TagBuilder i = new TagBuilder("i");

            i.Attributes.Add("class", "fa fa-minus-circle fa-fw");



            tb.InnerHtml = i + linkText;

            var tag = tb.ToString(TagRenderMode.Normal);

            return MvcHtmlString.Create(tag);

        }

        private static string JsEncode(this string s)
        {
            if (string.IsNullOrEmpty(s)) return "";
            int i;
            int len = s.Length;

            StringBuilder sb = new StringBuilder(len + 4);
            string t;

            for (i = 0; i < len; i += 1)
            {
                char c = s[i];
                switch (c)
                {
                    case '>':
                    case '"':
                    case '\\':
                        sb.Append('\\');
                        sb.Append(c);
                        break;
                    case '\b':
                        sb.Append("\\b");
                        break;
                    case '\t':
                        sb.Append("\\t");
                        break;
                    case '\n':
                        //sb.Append("\\n");
                        break;
                    case '\f':
                        sb.Append("\\f");
                        break;
                    case '\r':
                        //sb.Append("\\r");
                        break;
                    default:
                        if (c < ' ')
                        {
                            //t = "000" + Integer.toHexString(c); 
                            string tmp = new string(c, 1);
                            t = "000" + int.Parse(tmp, System.Globalization.NumberStyles.HexNumber);
                            sb.Append("\\u" + t.Substring(t.Length - 4));
                        }
                        else
                        {
                            sb.Append(c);
                        }
                        break;
                }
            }
            return sb.ToString();
        }
    }
}