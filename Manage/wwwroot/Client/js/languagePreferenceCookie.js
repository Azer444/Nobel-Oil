
$("#culture-change li").on("click", function myfunction()
{
    let lang = $(this).find(".language-direct").data("lang");
    let changeCultureForm = $("#changeculture-form");
    let culturesBox = $("#cultures-box");

    for (var i = 0; i < culturesBox[0].options.length; i++)
    {
        if (culturesBox[0].options[i].text == lang)
        {
            culturesBox[0].options[i].selected = true;
            break;
        }
    }

    changeCultureForm.submit();
})





////$("#language-select").ready(function () {

////    const language_dropdown = document.querySelector(".language-dropdown"),
////        language_dropdown_btn = language_dropdown.querySelector(".btn"),
////        langauge_options = language_dropdown.querySelectorAll(".dropdown-menu a"),

////        addClassToSelected = (option, lang) => {
////            if (option.dataset['lang'] === lang) {
////                option.classList.add("active");
////            }
////        },
////        setSelectedLanguage = (option) => {
////            const language = getCookie("languagePreference") || langauge_options[0].dataset["lang"];

////            language_dropdown_btn.innerHTML = language;
////            addClassToSelected(option, language)
////        },

////        changeLanguage = (e, option, lang) => {
////            createCookie("languagePreference", lang, 20);
////            setSelectedLanguage(option, lang)
////        },

////        initLanguage = () => [...langauge_options].forEach(option => {
////            const lang = option.dataset['lang'];

////            option.addEventListener("click", (e) => changeLanguage(e, option, lang))
////            setSelectedLanguage(option, lang)
////        })

////    initLanguage()

////});


