const iniciar = () => {
    console.log('antes de fetch');
  
    const response = fetch('https://api.github.com/users/ermogenes');
    console.log(response);
  
    console.log('depois de fetch');
  };
  
  document.addEventListener('DOMContentLoaded', iniciar);