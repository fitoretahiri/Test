
const DashboardRestoranti = (props) => {
    
    return ( 
        <div>
            <h1>{props.name ? 'Jeni Kyqur me sukses: '+props.name : 'Ju nuk jeni i kyqur'} </h1>
        </div>
     );
}
 
export default DashboardRestoranti;