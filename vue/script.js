var app = new Vue({
     el: '#app',
     data:
     {
         message:''
     },
    methods:{
        reverseM:function(){
            this.message = this.message.split('').reverse().join('')

        }
    }
 });
