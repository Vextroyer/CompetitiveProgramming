/*
https://leetcode.com/problems/restore-ip-addresses/

Monotonicity:
If a string s is not a valid ip address then any string s' which has s as its prefix is not a valid ip
address.

This is an special case of partitioning an array.
*/
class RestoreIP{
    public IList<string> Restore(string raw){
        IList<string> storage = new List<string>();//For storing the different ip addresses.
        
        List<string> address = new List<string>();//For storing the different parts of an ip address

        Generate(raw,0,storage,address);

        return storage;
    }
    private void Generate(string raw,int pos,IList<string> storage,List<string> address){
        if(address.Count > 4)return;
        if(pos == raw.Length){
            if(address.Count != 4)return;
            //Have a valid ip address
            storage.Add(ToAddress(address));
            return;
        }

        for(int i=0;pos + i < raw.Length;++i){
            string part = raw.Substring(pos,i+1);
            if(!ValidNumber(part))break;//Monotonicity

            address.Add(part);
            Generate(raw,pos + i + 1,storage,address);
            address.RemoveAt(address.Count - 1);//remove the last inserted
        }
    }
    //Determines if a given string is a number in [0,255]
    private bool ValidNumber(string raw){
        if(raw.Length > 1 && raw[0] == '0')return false;
        int part = int.Parse(raw);
        return (0 <= part && part <= 255);
    }
    //Turn a list of addresses part into an address
    private string ToAddress(List<string> parts){
        string address = "";
        for(int i=0;i<parts.Count;++i){
            if(i != 0)address = address + "." + parts[i];
            else address = parts[i];
        }
        return address;
    }
}