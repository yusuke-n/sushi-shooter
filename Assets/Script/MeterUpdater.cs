using System.Collections;
using System.Collections.Generic;

public class MeterUpdater
{
	int start;
	int end;
	int edge;
    int val;
    bool incr;
    int incr_value;

	public MeterUpdater(int start, int end, int edge_interval, bool incr = true, int incr_value = 1)
	{
		this.start = start;
		this.end = end;
		this.edge = edge_interval;
        this.val = start;
        this.incr = incr;
        this.incr_value = incr_value;
	}

	public int Update()
	{
        if (this.val == this.end + this.edge)
        {
            this.val = this.end;
            this.incr = false;
        }
        if (this.val == this.start - this.edge)
        {
            this.val = this.start;
            this.incr = true;
        }
        if (this.incr)
            this.val += this.incr_value;
        else
            this.val -= this.incr_value;

        if (this.val > this.end)
            return this.end;
        else if (this.val < this.start)
            return this.start;
        else
            return this.val;
    }
}
