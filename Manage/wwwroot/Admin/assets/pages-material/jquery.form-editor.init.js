/**
 * Theme: Metrica - Responsive Bootstrap 4 Admin Dashboard
 * Author: Mannatthemes
 * Editor Js
 */

$(document).ready(function () {
  if($("#elm1").length > 0){
      tinymce.init({
          selector: "textarea#elm1",
          theme: "modern",
          fontsize_formats: "8pt 10pt 12pt 14pt 18pt 24pt 36pt",
          height: 300,
          plugins: [
              "lists autosave advlist autoresize link charmap preview hr pagebreak",
              "visualblocks visualchars code fullscreen insertdatetime nonbreaking",
              "table contextmenu directionality emoticons template paste textcolor",
          ],
          toolbar: "sizeselect undo redo | fontselect fontsizeselect | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link image | preview | forecolor backcolor emoticons",
          style_formats: [
              {title: 'Bold text', inline: 'b'},
              {title: 'Red text', inline: 'span', styles: {color: '#ff0000'}},
              {title: 'Red header', block: 'h1', styles: {color: '#ff0000'}},
              {title: 'Example 1', inline: 'span', classes: 'example1'},
              {title: 'Example 2', inline: 'span', classes: 'example2'},
              {title: 'Table styles'},
              {title: 'Table row 1', selector: 'tr', classes: 'tablerow1'}
          ],
          fontsize_formats: "8pt 10pt 11pt 12pt 14pt 18pt 24pt 36pt",
      });
  }
});