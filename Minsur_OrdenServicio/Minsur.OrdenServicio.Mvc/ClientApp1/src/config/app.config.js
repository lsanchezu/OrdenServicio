import VeeValidate,  { Validator } from "vee-validate";

const AppConfig = {
    init(){
        Validator.extend('text_required', {
            getMessage: field => {
              return `El campo es requerido`;
            },
          
            validate: value => {
              return !isBlank(value);
            }
        });
          
        Validator.extend('select_required', {
            getMessage: field => {
              return `El campo es requerido`;
            },
            
            validate: value => {
              return parseInt(value) > 0;
            }
        });

        const dictionary = {
          es: {
            messages: {
              required: 'El campo es requerido.'
            }
          }
        };
        
        // Override and merge the dictionaries
        Validator.localize(dictionary);
    }
}

export default AppConfig