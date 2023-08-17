import './App.css';
import { useState } from 'react';

const fetchData = async (setResponse) => {
  const response = await fetch('/api/test');
  const data = await response.json();
  setResponse(data);
}

function App() {
  const [response, setResponse] = useState(undefined);

  return (
    <div style={{display: 'flex', justifyContent: 'center', alignItems: 'center'}}>
      <div style={{display: 'flex', flexDirection: 'column', gap: 8}}>
        <div style={{ margin: '0 auto' }}>
          <button onClick={() => fetchData(setResponse)}>Click Here</button>
        </div>

        {response && <div>{JSON.stringify(response, null, 2)}</div>}</div>
    </div>
  );
}

export default App;
