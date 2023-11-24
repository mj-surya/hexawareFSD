import logo from './logo.svg';
import './App.css';
import AddProduct from './Components/AddProduct';
import Products from './Components/Products';
import RegisterUser from './Components/RegisterUser';

function App() {
  return (
    <div class="container text-center">
  <div class="row">
    <div class="col">
      <Products/>
    </div>
    <div class="col">
      <AddProduct/>
    </div>
  </div>
  <div class="row" style={{'margin-top':30}}>
    <div class="col-md-4">
      <RegisterUser/>
    </div>
  </div>
</div>
  );
}

export default App;